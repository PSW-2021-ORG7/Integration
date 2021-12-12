using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
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

        public string SendPrescriptionSFTP(Prescription prescription, Medicine medicine)
        {
            try
            {
                string filename = prescription.PatientJMBG.Replace(" ", "") + ".txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"Output\", filename);
                File.WriteAllText(path, JsonConvert.SerializeObject(prescription));
                upload(filename);
                return filename;

            }
            catch (Exception e)
            {
                throw (e);
            }

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
