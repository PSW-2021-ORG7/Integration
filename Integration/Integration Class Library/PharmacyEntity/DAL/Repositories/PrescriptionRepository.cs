using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Renci.SshNet;

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
    
        public void SendPrescriptionSFTP(String filename)
        {
            upload(filename);

        }

        public void upload(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.3", "tester", "password")))
            {
                client.Connect();
                string sourceFile = Path.Combine(Environment.CurrentDirectory, @"Output\", fileName);
                using (Stream stream = File.OpenRead(sourceFile))
                {
                    client.UploadFile(stream, @"\public\" + fileName);
                }

                client.Disconnect();
            }
        }

    }
}
