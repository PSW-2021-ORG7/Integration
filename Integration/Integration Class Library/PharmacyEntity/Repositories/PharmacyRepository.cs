using Integration_Class_Library.DAL;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Integration_Class_Library.PharmacyEntity.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {

        private readonly IntegrationDbContext _context;
        public PharmacyRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public Pharmacy CreatePharmacy(Pharmacy pharmacy)
        {
            _context.Add(pharmacy);
            _context.SaveChanges();
            return pharmacy;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return _context.Pharmacies.ToList();
        }

        public Pharmacy GetPharmacyById(int id)
        {
            return _context.Pharmacies.Find(id);
        }

        public bool PutPharmacy(int id, Pharmacy pharmacy)
        {
            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                var entry = _context.Pharmacies.First(e => e.IdPharmacy == pharmacy.IdPharmacy);
                _context.Entry(entry).CurrentValues.SetValues(pharmacy);
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

        public bool DeletePharmacy(int id)
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

        private bool PharmacyExists(int id)
        {
            return _context.Pharmacies.Any(e => e.IdPharmacy == id);
        }

        public bool DownloadMedicationSpecification(String fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.3", "tester", "password")))
            {
                client.Connect();

                string sourceFileServer = @"\public\" + fileName;
                string sourceFileLocal = Path.Combine(Environment.CurrentDirectory, @"Downloads\", fileName);


                using (Stream stream = File.OpenWrite(sourceFileLocal))
                {
                    client.DownloadFile(sourceFileServer, stream);
                }

                client.Disconnect();
            }
            return true;
        }
    }
}
