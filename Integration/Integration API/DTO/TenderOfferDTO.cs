using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class TenderOfferDTO
    {
        public String TenderKey { get; set; }
        public String ApiKey { get; set; }
        public List<TenderOfferItemDTO> tenderingOfferItems { get; set; }
        public String PriceForAllAvailable { get; set; }
        public String PriceForAllRequired { get; set; }
        public String TotalNumberMissingMedicine { get; set; }

        public TenderOfferDTO()
        {
            this.tenderingOfferItems = new List<TenderOfferItemDTO>();
        }
    }
}
