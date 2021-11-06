using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Pharmacy> CreatePharmacy(Pharmacy pharmacy)
        {
            _context.Add(pharmacy);
            await _context.SaveChangesAsync();
            return pharmacy;
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

        public async Task<ActionResult<Pharmacy>> DeletePharmacy(String id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                //return NotFound(); ?
                return null;
            }

            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();

            return pharmacy;
        }

        private bool PharmacyExists(String id)
        {
            return _context.Pharmacies.Any(e => e.IdPharmacy == id);
        }
    }
}
