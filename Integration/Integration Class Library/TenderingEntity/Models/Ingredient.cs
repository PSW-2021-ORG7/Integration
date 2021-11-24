using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.TenderingEntity.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Medicine> Medicines { get; set; }
    }
}
