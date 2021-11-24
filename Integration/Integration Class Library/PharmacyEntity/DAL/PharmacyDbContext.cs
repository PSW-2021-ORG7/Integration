using Integration_Class_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration_Class_Library.PharmacyEntity.DAL
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy { IdPharmacy = "P1", NamePharmacy = "Irisfarm", ApiKeyPharmacy = "XYZX", Endpoint = "http://localhost:64677/", Adresa = "Kralja Petra I", Naselje = "Veternik"}              
            );
        }
     
    }
}
