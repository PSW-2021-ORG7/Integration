using Integration_API.DTO;
using Integration_Class_Library.Tendering.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
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

        public override Task StartAsync(CancellationToken stoppingToken)
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
            };
            channel.BasicConsume(queue: "tendering-offers-queue",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
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
    }
}
