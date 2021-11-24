using backend.Repositories.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.TenderingEntity.DAL.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly MedicineDbContext _dataContext;

        public MedicineRepository(MedicineDbContext dataContext) => _dataContext = dataContext;

        public bool MedicineExists(Medicine medicine)
        {
            if (_dataContext.Medicine.Any(m => m.Name.ToLower().Equals(medicine.Name.ToLower())  && m.DosageInMilligrams == medicine.DosageInMilligrams)) return true;
            return false;
        }

        public void Delete(Medicine medicine)
        {
            _dataContext.Medicine.Remove(medicine);
            _dataContext.SaveChanges();
        }

        public List<Medicine> GetAll() { 
            return _dataContext.Medicine.Include(m => m.Ingredients).ToList();
        }


       public Medicine GetByName(string name)
        {
            return _dataContext.Medicine.Include(m => m.Ingredients).SingleOrDefault(m => m.Name == name);
		}
		
 
        public Medicine GetByNameAndDose(string name, int dose)
        {
            return  _dataContext.Medicine.SingleOrDefault(m => m.Name.ToLower().Equals(name.ToLower()) && m.DosageInMilligrams == dose);
            
        }

        public bool Save(Medicine medicine)
        {
            if (_dataContext.Medicine.Any(m => m.Name == medicine.Name && m.DosageInMilligrams == medicine.DosageInMilligrams)) return false;

            _dataContext.Medicine.Add(medicine);
            _dataContext.SaveChanges();
            return true;
        }

        public bool Update(Medicine medicine)
        {
            bool success = false;
            var result = _dataContext.Medicine.SingleOrDefault(m => m.Id == medicine.Id);
            if (result != null)
            {
                _dataContext.Update(medicine);
                _dataContext.SaveChanges();
                success = true;
            }
            return success;

        }

        public Medicine GetByID(int id)
        {
            return _dataContext.Medicine.Include(m => m.Ingredients).SingleOrDefault(m => m.Id.Equals(id));
        }

    }
}
