using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.Models
{
    [Table("Pharmacy")]
    public class Pharmacy
    {
        [Key]
        public String IdPharmacy { get; set; }
        public String NamePharmacy { get; set; }
        public String ApiKeyPharmacy { get; set; }
        public String Endpoint { get; set; }
        public string Adresa { get; set; }
        public string Naselje { get; set; }
    }
  
}
