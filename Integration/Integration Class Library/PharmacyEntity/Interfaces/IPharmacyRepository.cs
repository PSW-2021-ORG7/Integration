using Integration_Class_Library.Models;
using System;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IPharmacyRepository
    {
        Pharmacy CreatePharmacy(Pharmacy pharmacy);
        List<Pharmacy> GetAllPharmacies();
        Pharmacy GetPharmacyById(String id);
        bool PutPharmacy(String id, Pharmacy pharmacy);
        bool DeletePharmacy(String id);
    }
}
