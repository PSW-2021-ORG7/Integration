using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration_Class_Library.Models
{
    public class Pharmacy
    {
        [Key]
        public String IdPharmacy { get; set; }
        public String NamePharmacy { get; set; }
        public String ApiKeyPharmacy { get; set; }
        public String Endpoint { get; set; }
    }
  
}
