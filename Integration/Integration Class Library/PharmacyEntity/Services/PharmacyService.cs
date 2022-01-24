using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.Events.PharmacyRegisteredEvent;
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
        private readonly ILogEventService<PharmacyRegisteredEventParams> _logEventService;

        public PharmacyService(IPharmacyRepository pharmacyRepository, ILogEventService<PharmacyRegisteredEventParams> logEventService)
        {
            this.pharmacyRepository = pharmacyRepository;
            _logEventService = logEventService;

        }
        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
           
        }

        public Pharmacy GetPharmacyById(int id)
        {
            return pharmacyRepository.GetPharmacyById(id);
        }

        public List<Pharmacy> GetPharmacies()
        {
            return pharmacyRepository.GetAllPharmacies();
        }

        public Pharmacy PostPharmacy(Pharmacy pharmacy)
        {
            Pharmacy created = pharmacyRepository.CreatePharmacy(pharmacy);
            if(created != null) _logEventService.LogEvent(new PharmacyRegisteredEventParams(created.IdPharmacy));

            return created;
        }

        public bool PutPharmacy(int id, Pharmacy pharmacy)
        {
            return pharmacyRepository.PutPharmacy(id, pharmacy);
        }


        public bool DeletePharmacy(int id)
        {
            return pharmacyRepository.DeletePharmacy(id);
        }

        public Pharmacy GetPharmacyByApiKey(string ApiKey)
        {
            return pharmacyRepository.GetPharmacyByApiKey(ApiKey);
        }

        public bool DownloadMedicationSpecification(String fileName)
        {
            try
            {
                return pharmacyRepository.DownloadMedicationSpecification(fileName);
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
