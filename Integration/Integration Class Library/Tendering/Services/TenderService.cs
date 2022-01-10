using Integration_Class_Library.Tendering.Interfaces;
using Integration_Class_Library.Tendering.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Services
{
    public class TenderService
    {
        ITenderRepository _tenderRepository;
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
