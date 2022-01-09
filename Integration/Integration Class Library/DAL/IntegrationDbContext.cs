﻿using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Models;
using Integration_Class_Library.SharedModel;
using Integration_Class_Library.Tendering;
using Integration_Class_Library.Tendering.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration_Class_Library.DAL
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TenderOffer>().OwnsMany(to => to.TenderOfferItems);
        }
    }
}