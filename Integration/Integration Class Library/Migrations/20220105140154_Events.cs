using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Class_Library.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRegistered_Pharmacy_PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered");

            migrationBuilder.DropIndex(
                name: "IX_PharmacyRegistered_PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered");

            migrationBuilder.DropColumn(
                name: "PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered");

            migrationBuilder.AddColumn<int>(
                name: "IdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyRegistered_PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered",
                column: "PharmacyIdPharmacy");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRegistered_Pharmacy_PharmacyIdPharmacy",
                schema: "Events",
                table: "PharmacyRegistered",
                column: "PharmacyIdPharmacy",
                principalTable: "Pharmacy",
                principalColumn: "IdPharmacy",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
