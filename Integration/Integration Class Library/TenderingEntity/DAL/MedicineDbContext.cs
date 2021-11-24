using Integration_Class_Library.TenderingEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration_Class_Library.TenderingEntity.DAL
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options) { }

        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineInventory> MedicineInventory { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<MedicineCombination> MedicineCombination { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

         /*   builder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();
         */
        }
    }
}

