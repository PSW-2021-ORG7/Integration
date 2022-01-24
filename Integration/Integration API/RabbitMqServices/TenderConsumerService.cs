using HospitalClassLibrary.Events.LogEvent;
using Integration_API.DTO;
using Integration_Class_Library.DAL;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Repositories;
using Integration_Class_Library.PharmacyEntity.Services;
using Integration_Class_Library.Tendering;
using Integration_Class_Library.Tendering.Models;
using Integration_Class_Library.Tendering.Repositories;
using Integration_Class_Library.Tendering.Services;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Integration_API.RabbitMQServices
{ 
    class TenderConsumerService : BackgroundService
    {
        
        IConnection connection;
        IModel channel;
        private CancellationToken cancellationToken;

        private TenderService _tenderService = new TenderService(new TenderRepository(new IntegrationDbContext()));
        private PharmacyService _pharmacyService = new PharmacyService(new PharmacyRepository(new IntegrationDbContext()));
        public override Task StartAsync(CancellationToken stoppingToken)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: "tendering-offers-queue",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonBody = Encoding.UTF8.GetString(body);
                    TenderOfferDTO offer = new TenderOfferDTO();

                    offer = JsonConvert.DeserializeObject<TenderOfferDTO>(jsonBody);
                    TenderOffer finalOffer = CreateOffer(offer);
                    _tenderService.AddTenderOffer(finalOffer);


                };
                channel.BasicConsume(queue: "tendering-offers-queue",
                                        autoAck: true,
                                        consumer: consumer);
                return base.StartAsync(cancellationToken);
            } catch (Exception e)
            {
                return base.StartAsync(cancellationToken);
            }
            
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public TenderOffer CreateOffer (TenderOfferDTO tenderOfferDTO)
        {
            //TenderOffer offer = Mapping.Mapper.Map<TenderOffer>(tenderOfferDTO);
            TenderOffer offer = new TenderOffer(Convert.ToDouble(tenderOfferDTO.PriceForAllAvailable), Convert.ToDouble(tenderOfferDTO.PriceForAllRequired), Convert.ToInt32(tenderOfferDTO.TotalNumberMissingMedicine));
            foreach(TenderOfferItem item in tenderOfferDTO.TenderingOfferItems)
            {
                offer.addItem(item);
            }

            Pharmacy pharmacy = _pharmacyService.GetPharmacyByApiKey(tenderOfferDTO.ApiKey);
            offer.setPharmacyId(pharmacy.IdPharmacy);

            Tender tender = _tenderService.GetTenderByKey(tenderOfferDTO.TenderKey);
            offer.setTenderId(tender.Id);
            
            return offer;
            
        }

    }
}
