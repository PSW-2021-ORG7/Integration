using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using System.Collections.Generic;

namespace Integration_Class_Library.TenderingEntity.Services
{
    public class MedicineInventoryService
    {
        IMedicineInventoryRepository medicineInventoryRepository;
        public MedicineInventoryService(IMedicineInventoryRepository medicineInventoryRepository)
        {
            this.medicineInventoryRepository = medicineInventoryRepository;
        }

        public bool Save(MedicineInventory medicineInventory)
        {
           return medicineInventoryRepository.Save(medicineInventory);
        }

        public bool Update(MedicineInventory medicineInventory)
        {
            if (medicineInventoryRepository.Update(medicineInventory)) return true;
            return false;
        }

        public List<MedicineInventory> UpdateMultipleMedicines(List<MedicineInventory> medicines)
        {
            List<MedicineInventory> medicinesUnableToUpdate = new List<MedicineInventory>();
            foreach (MedicineInventory medicine in medicines)
            {
                if (!medicineInventoryRepository.Update(medicine)) medicinesUnableToUpdate.Add(medicine);
            }
            return medicinesUnableToUpdate;
        }


        public bool DeleteMedicineInventory(MedicineInventory medicineInventory)
        {
            medicineInventoryRepository.Delete(medicineInventory);
            return true; //napomena!
        }

        public List<MedicineInventory> GetAll()
        {
            return medicineInventoryRepository.GetAll();
        }
    }
}

