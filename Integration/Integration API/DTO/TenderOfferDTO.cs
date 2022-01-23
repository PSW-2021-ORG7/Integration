using Integration_Class_Library.Tendering.Models;
using System;
using System.Collections.Generic;


namespace Integration_API.DTO
{
    public class TenderOfferDTO
    {
        public String TenderKey { get; set; }
        public String ApiKey { get; set; }
        public List<TenderOfferItem> TenderingOfferItems { get; set; }
        public String PriceForAllAvailable { get; set; }
        public String PriceForAllRequired { get; set; }
        public String TotalNumberMissingMedicine { get; set; }

        public TenderOfferDTO()
        {
            this.TenderingOfferItems = new List<TenderOfferItem>();
        }
    }
}
