using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using System.Collections.Generic;

namespace Integration_Class_Library.TenderingEntity.Services
{
    public class MedicineCombinationService
    {
        private IMedicineCombinationRepository _medicineCombinationRepository;

        public MedicineCombinationService(IMedicineCombinationRepository medicineCombinationRepository)
        {
            this._medicineCombinationRepository = medicineCombinationRepository;
        }

        public bool Save(int id, int m)
        {
            return _medicineCombinationRepository.Save(new MedicineCombination(id, m));
        }

        public List<MedicineCombination> GetMedicinesCombination(int firstMedicineId)
        {
            return _medicineCombinationRepository.GetByFirstMedicineId(firstMedicineId);
        }
    }
}
