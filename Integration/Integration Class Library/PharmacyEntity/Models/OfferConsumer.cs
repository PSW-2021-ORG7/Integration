using backend.Model;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Models
{
    public class OfferConsumer : IConsumer<Offer>
    {
        ILogger<OfferConsumer> _logger;

        public OfferConsumer(ILogger<OfferConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Offer> context)
        {
            _logger.LogInformation("Value: {Name}", context.Message.Name);
            System.Diagnostics.Debug.WriteLine(context.Message.Name);
        }
    }
}
