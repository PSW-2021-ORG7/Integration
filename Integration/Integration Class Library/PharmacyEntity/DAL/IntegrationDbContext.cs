﻿using Integration_Class_Library.Events;
using Integration_Class_Library.Events.FeedbackCreatedEvent;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Models;
using Integration_Class_Library.SharedModel;
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
        public DbSet<Prescription> Prescription { get; set; }

        //Events
        public DbSet<PharmacyRegistered> PharmacyRegistered { get; set; }
        public DbSet<FeedbackCreated> FeedbackCreated { get; set; }
    }
}
