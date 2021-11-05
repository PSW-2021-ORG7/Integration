using Integration_Class_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<Pharmacy> CreatePharmacy(Pharmacy pharmacy);
        Task<List<Pharmacy>> GetAllPharmacies();
        Task<Pharmacy> GetPharmacyById(String id);
        Task<int> PutPharmacy(String id, Pharmacy pharmacy);
        Task<ActionResult<Pharmacy>> DeletePharmacy(String id);
    }
}
