using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Integration_Class_Library.TenderingEntity.Models 
{ 
    public class MedicineInventory
    {
        public MedicineInventory() { }
        public MedicineInventory(int medicineId)
        {
            MedicineId = medicineId;
            Quantity = 0;
        }

        [JsonConstructor]
        public MedicineInventory(int medicineId, int quantity)
        {
            MedicineId = medicineId;
            Quantity = quantity;
        }

        [Key]
        public int MedicineId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
