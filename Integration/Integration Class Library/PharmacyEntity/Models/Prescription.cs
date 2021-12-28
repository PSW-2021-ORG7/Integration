using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.Models
{
    [Table("Prescriptions")]
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public string Patient { get; set; }
        public string PatientJMBG { get; set; }
        public string Doctor { get; set; }
        public int MedicineId { get; set; }
        public int DurationInDays { get; set; }
        public int TimesPerDay { get; set; }
        public string Description { get; set; }
    }
}
