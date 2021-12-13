using Integration_Class_Library.Models;
using Integration_Class_Library.TenderingEntity.Models;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAllPrescriptions();
        Prescription GetPrescriptionById(int id);
        void SendPrescriptionSFTP(string filename);
    }
}
