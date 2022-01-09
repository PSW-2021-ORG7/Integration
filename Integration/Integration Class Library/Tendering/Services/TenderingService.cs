using Integration_Class_Library.Tendering.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Services
{
    public class TenderingService
    {
        public TenderingService() { }

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
