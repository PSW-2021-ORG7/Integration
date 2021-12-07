using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration_Class_Library.PharmacyEntity.DAL
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

     
    }
}
