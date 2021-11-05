using Integration_Class_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.PharmacyEntity.DAL
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }

        // only for testing purposes
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy { IdPharmacy = "P1", NamePharmacy = "Pharmacy 1", ApiKeyPharmacy = "ABCD1234", Endpoint = "www.pharmacy1.rs" },
                new Pharmacy { IdPharmacy = "P2", NamePharmacy = "Pharmacy 2", ApiKeyPharmacy = "EFGH1234", Endpoint = "www.pharmacy2.rs" }

            );
        }
       */
    }
}
