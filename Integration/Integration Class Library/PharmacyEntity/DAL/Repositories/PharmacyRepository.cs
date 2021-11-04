using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.DAL.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {

        private readonly PharmacyDbContext _context;
        public PharmacyRepository(PharmacyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pharmacy>> GetAllPharmacies()
        {
            return await _context.Pharmacies.ToListAsync();
        }

        public async Task<Pharmacy> GetPharmacyById(string id)
        {
            return await _context.Pharmacies.FindAsync(id);
        }

        public async Task<int> PutPharmacy(string id, Pharmacy pharmacy)
        {
            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
                {
                    return -1;
                }

                throw;
            }

            return 0;
        }

        private bool PharmacyExists(String id)
        {
            return _context.Pharmacies.Any(e => e.IdPharmacy == id);
        }
    }
}
