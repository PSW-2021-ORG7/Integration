using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Models
{
    public class TenderOfferItem
    {
        public string MedicineName { get; private set; }
        public int DosageInMilligrams { get; private set; }
        public string Manufacturer { get; private set; }
        public int MissingQuantity { get; private set; }
        public double PriceForSingleEntity { get; private set; }
        public double PriceForAllAvailableEntity { get; private set; }
        public double PriceForAllRequiredEntity { get; private set; }

    }
}
