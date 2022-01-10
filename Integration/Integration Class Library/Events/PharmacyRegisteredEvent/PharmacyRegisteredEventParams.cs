using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.PharmacyRegisteredEvent
{
    public class PharmacyRegisteredEventParams : EventParams
    {
        public int IdPharmacy { get; set; }

        public PharmacyRegisteredEventParams(int idPharmacy)
        {
            this.IdPharmacy = idPharmacy;
        }
    }
}
