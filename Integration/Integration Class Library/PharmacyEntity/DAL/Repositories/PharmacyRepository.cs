using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.PharmacyEntity.DAL.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {

        private readonly PharmacyDbContext _context;
        public PharmacyRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        public Pharmacy CreatePharmacy(Pharmacy pharmacy)
        {
            _context.Add(pharmacy);
            _context.SaveChangesAsync();
            return pharmacy;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return _context.Pharmacies.ToList();
        }

        public Pharmacy GetPharmacyById(string id)
        {
            return _context.Pharmacies.Find(id);
        }

        public bool PutPharmacy(string id, Pharmacy pharmacy)
        {
            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
                {
                    return false;
                }

                throw;
            }

            return true;
        }

        public bool DeletePharmacy(String id)
        {
            var pharmacy = _context.Pharmacies.Find(id);
            if (pharmacy == null)
            {
                return false;
            }

            _context.Pharmacies.Remove(pharmacy);
            _context.SaveChanges();
            return true;
        }

        private bool PharmacyExists(String id)
        {
            return _context.Pharmacies.Any(e => e.IdPharmacy == id);
        }
    }
}
