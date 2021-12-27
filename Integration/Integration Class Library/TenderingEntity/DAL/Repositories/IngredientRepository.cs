using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.TenderingEntity.DAL.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MedicineDbContext _dataContext;

        public IngredientRepository(MedicineDbContext dataContext) => _dataContext = dataContext;

        public void Delete(Ingredient ingredient)
        {
            _dataContext.Ingredient.Remove(ingredient);
            _dataContext.SaveChanges();
        }

        public List<Ingredient> GetAll()
        {
            return _dataContext.Ingredient.ToList();
        }

        public bool Save(Ingredient ingredient)
        {
            if (_dataContext.Ingredient.Any(i => i.Name == ingredient.Name)) return false;

            _dataContext.Ingredient.Add(ingredient);
            _dataContext.SaveChanges();
            return true;
        }

        public bool Update(Ingredient ingredient)
        {
            bool success = false;
            var result = _dataContext.Ingredient.SingleOrDefault(m => m.Id == ingredient.Id);
            if (result != null)
            {
                _dataContext.Update(ingredient);
                _dataContext.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}
