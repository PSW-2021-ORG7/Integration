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

        public void sendRequestToPharmacy(String messageToSend)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tendering-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                String message = messageToSend;
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "",
                                     routingKey: "tendering-queue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
