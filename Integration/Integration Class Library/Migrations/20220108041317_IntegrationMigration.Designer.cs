﻿// <auto-generated />
using System;
using Integration_Class_Library.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_Class_Library.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20220108041317_IntegrationMigration")]
    partial class IntegrationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Integration_Class_Library.Models.Pharmacy", b =>
                {
                    b.Property<int>("IdPharmacy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ApiKeyPharmacy")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Contact")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endpoint")
                        .HasColumnType("text");

                    b.Property<string>("NamePharmacy")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.HasKey("IdPharmacy");

                    b.ToTable("Pharmacy");
                });

            modelBuilder.Entity("Integration_Class_Library.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Doctor")
                        .HasColumnType("text");

                    b.Property<int>("DurationInDays")
                        .HasColumnType("integer");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<string>("Patient")
                        .HasColumnType("text");

                    b.Property<string>("PatientJMBG")
                        .HasColumnType("text");

                    b.Property<int>("TimesPerDay")
                        .HasColumnType("integer");

                    b.HasKey("IdPrescription");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Integration_Class_Library.PharmacyEntity.Models.Feedback", b =>
                {
                    b.Property<int>("IdFeedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContentFeedback")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdPharmacy")
                        .HasColumnType("integer");

                    b.HasKey("IdFeedback");

                    b.ToTable("Response");
                });

            modelBuilder.Entity("Integration_Class_Library.Tendering.Models.TenderOffer", b =>
                {
                    b.Property<int>("IdTenderOffer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdPharmacy")
                        .HasColumnType("integer");

                    b.Property<int>("IdTender")
                        .HasColumnType("integer");

                    b.Property<double>("PriceForAllAvailable")
                        .HasColumnType("double precision");

                    b.Property<double>("PriceForAllRequired")
                        .HasColumnType("double precision");

                    b.Property<int>("TotalNumberMissingMedicine")
                        .HasColumnType("integer");

                    b.HasKey("IdTenderOffer");

                    b.ToTable("TenderOffers");
                });

            modelBuilder.Entity("Integration_Class_Library.Tendering.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdWinnerPharmacy")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("Integration_Class_Library.Tendering.Models.TenderOffer", b =>
                {
                    b.OwnsMany("Integration_Class_Library.Tendering.Models.TenderOfferItem", "TenderOfferItems", b1 =>
                        {
                            b1.Property<int>("TenderOfferIdTenderOffer")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("DosageInMilligrams")
                                .HasColumnType("integer");

                            b1.Property<string>("Manufacturer")
                                .HasColumnType("text");

                            b1.Property<string>("MedicineName")
                                .HasColumnType("text");

                            b1.Property<int>("MissingQuantity")
                                .HasColumnType("integer");

                            b1.Property<double>("PriceForAllAvailableEntity")
                                .HasColumnType("double precision");

                            b1.Property<double>("PriceForAllRequiredEntity")
                                .HasColumnType("double precision");

                            b1.Property<double>("PriceForSingleEntity")
                                .HasColumnType("double precision");

                            b1.HasKey("TenderOfferIdTenderOffer", "Id");

                            b1.ToTable("TenderOfferItem");

                            b1.WithOwner()
                                .HasForeignKey("TenderOfferIdTenderOffer");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}