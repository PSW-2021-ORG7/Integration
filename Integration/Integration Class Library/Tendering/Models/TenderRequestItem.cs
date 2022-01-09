using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Models
{
    public class TenderRequestItem
    {
        public String MedicineName { get; set; }
        public int DosageInMilligrams { get; set; }
        public String Manufacturer { get; set; }
        public int RequiredQuantity { get; set; }

        public TenderRequestItem() { }
    }
}
