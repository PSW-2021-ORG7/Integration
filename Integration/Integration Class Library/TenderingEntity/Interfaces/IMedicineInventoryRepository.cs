using Integration_Class_Library.TenderingEntity.Models;

namespace Integration_Class_Library.TenderingEntity.Interfaces
{
    public interface IMedicineInventoryRepository : IGenericRepository<MedicineInventory>
    {
        bool CheckMedicineQuantity(MedicineInventory medicineInventory);
    }
}
