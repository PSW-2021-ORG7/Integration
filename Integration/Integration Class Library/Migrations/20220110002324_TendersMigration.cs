using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_Class_Library.Migrations
{
    public partial class TendersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    IdPharmacy = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamePharmacy = table.Column<string>(nullable: true),
                    ApiKeyPharmacy = table.Column<string>(nullable: true),
                    Endpoint = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.IdPharmacy);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Patient = table.Column<string>(nullable: true),
                    PatientJMBG = table.Column<string>(nullable: true),
                    Doctor = table.Column<string>(nullable: true),
                    MedicineId = table.Column<int>(nullable: false),
                    DurationInDays = table.Column<int>(nullable: false),
                    TimesPerDay = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPharmacy = table.Column<int>(nullable: false),
                    ContentFeedback = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.IdFeedback);
                });

            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    IdTenderOffer = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTender = table.Column<int>(nullable: false),
                    IdPharmacy = table.Column<int>(nullable: false),
                    PriceForAllAvailable = table.Column<double>(nullable: false),
                    PriceForAllRequired = table.Column<double>(nullable: false),
                    TotalNumberMissingMedicine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => x.IdTenderOffer);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IdWinnerPharmacy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderOfferItem",
                columns: table => new
                {
                    TenderOfferIdTenderOffer = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineName = table.Column<string>(nullable: true),
                    MedicineDosage = table.Column<int>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    MissingQuantity = table.Column<int>(nullable: false),
                    PriceForSingleEntity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOfferItem", x => new { x.TenderOfferIdTenderOffer, x.Id });
                    table.ForeignKey(
                        name: "FK_TenderOfferItem_TenderOffers_TenderOfferIdTenderOffer",
                        column: x => x.TenderOfferIdTenderOffer,
                        principalTable: "TenderOffers",
                        principalColumn: "IdTenderOffer",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "TenderOfferItem");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "TenderOffers");
        }
    }
}
