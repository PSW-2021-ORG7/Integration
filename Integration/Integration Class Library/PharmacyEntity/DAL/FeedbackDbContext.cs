using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration_Class_Library.PharmacyEntity.DAL
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
            : base(options)
        {
        }
        public DbSet<Feedback> Feedback { get; set; }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { IdFeedback = "F1", IdPharmacy = "P2", ContentFeedback = "This hospital sucks" }

            ); 
        }
    }
}
