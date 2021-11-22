using Integration_Class_Library.Tendering.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Integration_Class_Library.Tendering.Service
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        private readonly IServiceScopeFactory scopeFactory;

        public RabbitMQService(IServiceScopeFactory scopeFactory) {
            this.scopeFactory = scopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);
            Offer offer = new Offer();
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                                 exchange: "logs",
                                 routingKey: "");


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {

                using (var scope = scopeFactory.CreateScope())
                {
                  /*  var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                    IDrugstoreOfferRepository repo = new DrugstoreOfferRepository(dbContext);
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);

                    try
                    {   // try deserialize with default datetime format
                        offer = JsonConvert.DeserializeObject<Offer>(jsonMessage);
                        //Console.WriteLine(offer.IsPublished);
                    }
                    catch (Exception)     // datetime format not default, deserialize with Java format (milliseconds since 1970/01/01)
                    {
                        Console.WriteLine("Can't");
                    }
                    Console.WriteLine(" [x] Received {0}", offer);
                    repo.Save(offer);  */

                }
            };

            channel.BasicConsume(queue: queueName,
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
