using Integration_Class_Library.Tendering.Interfaces;
using Integration_Class_Library.Tendering.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Services;
using Integration_Class_Library.PharmacyEntity.Repositories;
using Integration_Class_Library.DAL;

namespace Integration_Class_Library.Tendering.Services
{
    public class TenderService
    {
        ITenderRepository _tenderRepository;
        private PharmacyService _pharmacyService = new PharmacyService(new PharmacyRepository(new IntegrationDbContext()));
        public TenderService(ITenderRepository tenderRepository) 
        {
            this._tenderRepository = tenderRepository;
        }

        public bool CreateTender(Tender tender)
        {
            return _tenderRepository.CreateTender(tender);
        }

        public Tender GetTenderByKey(string key)
        {
            return _tenderRepository.GetTenderByKey(key);
        }

        public List<Tender> GetAllTenders()
        {
            return _tenderRepository.GetAllTenders();
        }

        public Tender GetTenderById(int id)
        {
            return _tenderRepository.GetTenderById(id);
        }

        public List<Tender> GetAllActiveTenders()
        {
            return _tenderRepository.GetActiveTenders();
        }

        public void AddTenderOffer(TenderOffer offer)
        {
            _tenderRepository.CreateTenderOffer(offer);
        }

        public List<TenderOffer> GetAllTenderOffersByTenderId(int id)
        {
            return _tenderRepository.GetAllTenderOffersByTenderId(id);
        }

        public bool SetWinner(int idTender, int idWinner)
        {
            Tender tender = GetTenderById(idTender);
            tender.setActivity(false);
            tender.setWinner(idWinner);
            return _tenderRepository.SetWinner(tender);

        }

        public bool CloseTender(int idTender)
        {
            Tender tender = GetTenderById(idTender);
            tender.setActivity(false);
            return _tenderRepository.SetWinner(tender);

        }

        public bool SendEmail(int idTender)
        {
            List<EmailMessage> emails = GenerateEmailContent(idTender);
            EmailConfiguration config = new EmailConfiguration();
            
            foreach(EmailMessage email in emails)
            {
                MimeMessage emailToSend = CreateEmailMessage(email, config);
                Send(emailToSend, config);
            }

            return true;
        }

        private List<EmailMessage> GenerateEmailContent(int idTender)
        {
            List<EmailMessage> messages = new List<EmailMessage>();
            Tender tender = _tenderRepository.GetTenderById(idTender);
            List<TenderOffer> offers = _tenderRepository.GetAllTenderOffersByTenderId(idTender);

            foreach(TenderOffer offer in offers)
            {
                Pharmacy pharmacy = _pharmacyService.GetPharmacyById(offer.IdPharmacy);
                string body = CreateBody(offer, tender.IdWinnerPharmacy);
                string subject = "Results For Tender ID: " + tender.Id + " And Pharmacy ID: " + offer.IdPharmacy;
                EmailMessage message = new EmailMessage(pharmacy.Email, subject, body);
                messages.Add(message);
            }

            
            return messages;
        }

        private string CreateBody(TenderOffer offer, int idWinnerPharmacy)
        {
            StringBuilder builder = new StringBuilder();
     
            if(offer.IdPharmacy != idWinnerPharmacy)
            {
                builder.AppendLine("We are sorry to inform you that you did not win this tender.");
            }
            else
            {
                builder.AppendLine("Congratulations! You won this tender.\n Offer Details: \n")
                        .AppendLine("Total Sum: " + offer.PriceForAllAvailable)
                        .AppendLine();
                
                foreach (TenderOfferItem item in offer.TenderOfferItems)
                {
                    builder.AppendLine()
                            .AppendLine("Medicine: " + item.MedicineName + " " + item.MedicineDosage + "mg x " + item.AvailableQuantity)
                            .AppendLine("Price: " + item.PriceForSingleEntity);                 
                }
            }
            
            return builder.ToString();
        }

        private MimeMessage CreateEmailMessage(EmailMessage message, EmailConfiguration config)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Admin", config.From));
            emailMessage.To.Add(new MailboxAddress("User",config.From));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage, EmailConfiguration emailConfig)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    CheckConnection(client, emailConfig, mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
 
                }
            }
        }

        private void CheckConnection(SmtpClient client, EmailConfiguration _emailConfig, MimeMessage mailMessage)
        {
            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, false);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
            client.Send(mailMessage);
        }

        public void sendRequestToPharmacy(TenderRequest tenderRequest)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tendering-requests-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                TenderRequest tenderRequestToSend = tenderRequest;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tenderRequestToSend));

                channel.BasicPublish(exchange: "",
                                     routingKey: "tendering-requests-queue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
