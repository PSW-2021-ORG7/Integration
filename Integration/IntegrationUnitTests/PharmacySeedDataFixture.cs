using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace IntegrationTests.Model
{
    public class PharmacySeedDataFixture : IDisposable
    {
        public PharmacyDbContext context { get; private set; } 

        public PharmacySeedDataFixture()
        {
            var options = new DbContextOptionsBuilder<PharmacyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            context = new PharmacyDbContext(options);

            context.Pharmacies.Add(new Pharmacy { IdPharmacy = "P1", ApiKeyPharmacy = "K1", Endpoint = "www.p1.com" });
            context.Pharmacies.Add(new Pharmacy { IdPharmacy = "P2", ApiKeyPharmacy = "K2", Endpoint = "www.p2.com" });
            context.Pharmacies.Add(new Pharmacy { IdPharmacy = "P3", ApiKeyPharmacy = "K3", Endpoint = "www.p3.com" });
            context.SaveChanges();
        }
        public void Dispose()
        {         
            context.Dispose();
        }
    }
}
