using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.Models
{
    [Table("Pharmacy")]
    public class Pharmacy
    {
        [Key]
        public int IdPharmacy { get; set; }
        public String NamePharmacy { get; set; }
        public String ApiKeyPharmacy { get; set; }
        public String Endpoint { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public String Notes { get; set; }
    }
  
}
