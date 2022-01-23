using Integration_Class_Library.Events;
using Integration_Class_Library.Events.FeedbackCreatedEvent;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Models;
using Integration_Class_Library.SharedModel;
using Integration_Class_Library.Tendering;
using Integration_Class_Library.Tendering.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Integration_Class_Library.DAL
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext() { }
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
		public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
		
        //Events
        public DbSet<PharmacyRegistered> PharmacyRegistered { get; set; }
        public DbSet<FeedbackCreated> FeedbackCreated { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connection = "User ID=postgres;Password=psql;Server=localhost;Port=5432;Database=Hospital;Integrated Security=true;Pooling=true;";
            optionsBuilder.UseNpgsql(connection);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TenderOffer>().OwnsMany(to => to.TenderOfferItems);
        }
    }
}
