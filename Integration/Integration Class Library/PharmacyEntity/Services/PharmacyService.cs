using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Services
{
    public class PharmacyService
    {
        IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository) => this.pharmacyRepository = pharmacyRepository;


        public Pharmacy GetPharmacyById(String id)
        {
            return pharmacyRepository.GetPharmacyById(id);
        }

        public List<Pharmacy> GetPharmacies()
        {
            return pharmacyRepository.GetAllPharmacies();
        }

        public Pharmacy PostPharmacy([FromBody] Pharmacy pharmacy)
        {
            return pharmacyRepository.CreatePharmacy(pharmacy);
        }

        public bool PutPharmacy(String id, Pharmacy pharmacy)
        {
            return pharmacyRepository.PutPharmacy(id, pharmacy);
        }


        public bool DeletePharmacy(String id)
        {
            return pharmacyRepository.DeletePharmacy(id);
        }

        public bool DownloadMedicationSpecification(String fileName)
        {
            try
            {
                return pharmacyRepository.DownloadMedicationSpecification(fileName);
            }
            catch (Exception e)
            {
                throw (e);
            }
            
        }
    }
}
