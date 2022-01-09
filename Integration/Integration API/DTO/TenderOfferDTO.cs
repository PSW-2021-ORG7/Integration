using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class TenderOfferDTO
    {
        public List<TenderOfferItemDTO> tenderingOfferItems { get; set; }

        public TenderOfferDTO()
        {
            this.tenderingOfferItems = new List<TenderOfferItemDTO>();
        }
    }
}
