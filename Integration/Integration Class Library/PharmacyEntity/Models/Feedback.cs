using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.PharmacyEntity.Models
{
    [Table("Response")]
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
