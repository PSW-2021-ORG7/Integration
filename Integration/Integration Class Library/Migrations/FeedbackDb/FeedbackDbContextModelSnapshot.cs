﻿// <auto-generated />
using Integration_Class_Library.PharmacyEntity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_Class_Library.Migrations.FeedbackDb
{
    [DbContext(typeof(FeedbackDbContext))]
    partial class FeedbackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Integration_Class_Library.PharmacyEntity.Models.Feedback", b =>
                {
                    b.Property<string>("IdFeedback")
                        .HasColumnType("text");

                    b.Property<string>("ContentFeedback")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdPharmacy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdFeedback");

                    b.ToTable("Response");

                    b.HasData(
                        new
                        {
                            IdFeedback = "F1",
                            ContentFeedback = "This hospital sucks",
                            IdPharmacy = "P2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
