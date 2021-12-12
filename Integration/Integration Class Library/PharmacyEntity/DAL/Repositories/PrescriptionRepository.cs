using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.PharmacyEntity.DAL.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly IntegrationDbContext _context;
        public PrescriptionRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public List<Prescription> GetAllPrescriptions()
        {
            return _context.Prescription.ToList();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return _context.Prescription.Find(id);
        }
    }
}
