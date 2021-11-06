using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Integration_Class_Library.PharmacyEntity.Models
{
    public class Feedback
    {
        [Key]
        public String IdFeedback { get; set; }
        [Required]
        public String IdPharmacy { get; set; }
        [Required]
        public String ContentFeedback { get; set; }
    }
}
