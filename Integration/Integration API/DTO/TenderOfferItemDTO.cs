using Integration_Class_Library.Tendering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class TenderOfferItemDTO : ValueObject
    {
        public string MedicineName { get; set; }
        public int MedicineDosage { get; set; }
        public int AvailableQuantity { get; set; }
        public int MissingQuantity { get; set; }
        public double PriceForSingleEntity { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
