using backend.Repositories.Interfaces;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.PharmacyEntity.Services
{
    public class PrescriptionService
    {
        IPrescriptionRepository prescriptionRepository;
        IMedicineRepository medicineRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository) 
        {
            this.prescriptionRepository = prescriptionRepository;
            this.medicineRepository = medicineRepository;
        }
       

        public List<Prescription> GetAllPrescriptions()
        {
            return prescriptionRepository.GetAllPrescriptions();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return prescriptionRepository.GetPrescriptionById(id);
        }

        public string SendPrescriptionSFTP(Prescription prescription)
        {
            Medicine medicine = medicineRepository.GetByID(prescription.MedicineId);
            return prescriptionRepository.SendPrescriptionSFTP(prescription, medicine);
        }
    }

}
