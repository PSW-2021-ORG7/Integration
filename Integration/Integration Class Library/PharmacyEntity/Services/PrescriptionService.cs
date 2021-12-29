using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using System;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Services
{
    public class PrescriptionService
    {
        IPrescriptionRepository prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            this.prescriptionRepository = prescriptionRepository;

        }


        public List<Prescription> GetAllPrescriptions()
        {
            return prescriptionRepository.GetAllPrescriptions();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return prescriptionRepository.GetPrescriptionById(id);
        }

        /*   public string SendPrescriptionSFTP(Prescription prescription)
           {
               Medicine medicine = medicineRepository.GetByID(prescription.MedicineId);
               return prescriptionRepository.SendPrescriptionSFTP(prescription, medicine);
           }
        */

        public void SendPrescriptionSFTP(String fileName)
        {
            prescriptionRepository.SendPrescriptionSFTP(fileName);
        }

      
    }
}
