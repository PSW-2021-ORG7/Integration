using HospitalClassLibrary.Events;
using Integration_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Integration_Class_Library.Events
{
    [Table(nameof(PharmacyRegistered), Schema = "Events")]
    public class PharmacyRegistered : Event
    {
        public int IdPharmacy { get; set; }
    }
}
