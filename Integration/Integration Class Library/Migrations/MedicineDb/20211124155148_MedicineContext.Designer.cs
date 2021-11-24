﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Integration_Class_Library.TenderingEntity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_Class_Library.Migrations.MedicineDb
{
    [DbContext(typeof(MedicineDbContext))]
    [Migration("20211124155148_MedicineContext")]
    partial class MedicineContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DosageInMilligrams")
                        .HasColumnType("integer");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<List<string>>("PossibleReactions")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("PotentialDangers")
                        .HasColumnType("text");

                    b.Property<List<string>>("SideEffects")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("WayOfConsumption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.MedicineCombination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FirstMedicineId")
                        .HasColumnType("integer");

                    b.Property<int>("SecondMedicineId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FirstMedicineId");

                    b.HasIndex("SecondMedicineId");

                    b.ToTable("MedicineCombination");
                });

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.MedicineInventory", b =>
                {
                    b.Property<int>("MedicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MedicineId");

                    b.ToTable("MedicineInventory");
                });

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.Medicine", b =>
                {
                    b.HasOne("Integration_Class_Library.TenderingEntity.Models.Ingredient", null)
                        .WithMany("Medicines")
                        .HasForeignKey("IngredientId");
                });

            modelBuilder.Entity("Integration_Class_Library.TenderingEntity.Models.MedicineCombination", b =>
                {
                    b.HasOne("Integration_Class_Library.TenderingEntity.Models.Medicine", "FirstMedicine")
                        .WithMany()
                        .HasForeignKey("FirstMedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Integration_Class_Library.TenderingEntity.Models.Medicine", "SecondMedicine")
                        .WithMany()
                        .HasForeignKey("SecondMedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}