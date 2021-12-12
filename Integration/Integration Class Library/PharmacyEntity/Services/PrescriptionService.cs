using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.PharmacyEntity.Services
{
    public class PrescriptionService
    {
        IPrescriptionRepository prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository) => this.prescriptionRepository = prescriptionRepository;

        public List<Prescription> GetAllPrescriptions()
        {
            return prescriptionRepository.GetAllPrescriptions();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return prescriptionRepository.GetPrescriptionById(id);
        }
    }

}
