using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using System;

namespace backend.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        bool MedicineExists(Medicine medicine);
        Medicine GetByName(string name);
        Medicine GetByID(int id);
        Medicine GetByNameAndDose(string name, int dose);
        bool ProcessOrder(Medicine medicine, int quantity);

    }
}
