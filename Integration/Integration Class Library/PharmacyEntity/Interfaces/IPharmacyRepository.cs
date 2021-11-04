using Integration_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<List<Pharmacy>> GetAllPharmacies();
        Task<Pharmacy> GetPharmacyById(String id);
        Task<int> PutPharmacy(String id, Pharmacy pharmacy);
    }
}
