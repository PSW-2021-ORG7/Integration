using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.PharmacyEntity.Models
{
    [Table("Response")]
    public class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }
        [Required]
        public int IdPharmacy { get; set; }
        [Required]
        public String ContentFeedback { get; set; }
    }
}
