using Integration_Class_Library.TenderingEntity.Models;
using System.Collections.Generic;

namespace Integration_Class_Library.TenderingEntity.Interfaces
{
    public interface IMedicineCombinationRepository : IGenericRepository<MedicineCombination>
    {
        List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId);
    }
}
