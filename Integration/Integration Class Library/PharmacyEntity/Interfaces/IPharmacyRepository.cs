using Integration_Class_Library.Models;
using System;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IPharmacyRepository
    {
        Pharmacy CreatePharmacy(Pharmacy pharmacy);
        List<Pharmacy> GetAllPharmacies();
        Pharmacy GetPharmacyById(int id);
        bool PutPharmacy(int id, Pharmacy pharmacy);
        bool DeletePharmacy(int id);
        bool DownloadMedicationSpecification(String fileName);
        Pharmacy GetPharmacyByApiKey(string ApiKey);
    }
}
