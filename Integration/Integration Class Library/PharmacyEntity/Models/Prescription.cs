using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.Models
{
    [Table("Prescriptions")]
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        string Patient { get; set; }
        string PatientJMBG { get; set; }
        string Doctor { get; set; }
        int MedicineId { get; set; }
        int DurationInDays { get; set; }
        int TimesPerDay { get; set; }
        string Description { get; set; }
    }
}
