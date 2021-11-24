using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Class_Library.Migrations
{
    public partial class MedicineContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "IdPharmacy",
                keyValue: "P2");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacy");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Pharmacy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naselje",
                table: "Pharmacy",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy",
                column: "IdPharmacy");

            migrationBuilder.UpdateData(
                table: "Pharmacy",
                keyColumn: "IdPharmacy",
                keyValue: "P1",
                columns: new[] { "Adresa", "ApiKeyPharmacy", "Endpoint", "NamePharmacy", "Naselje" },
                values: new object[] { "Kralja Petra I", "XYZX", "http://localhost:64677/", "Irisfarm", "Veternik" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacy",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Naselje",
                table: "Pharmacy");

            migrationBuilder.RenameTable(
                name: "Pharmacy",
                newName: "Pharmacies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "IdPharmacy");

            migrationBuilder.UpdateData(
                table: "Pharmacies",
                keyColumn: "IdPharmacy",
                keyValue: "P1",
                columns: new[] { "ApiKeyPharmacy", "Endpoint", "NamePharmacy" },
                values: new object[] { "ABCD1234", "www.pharmacy1.rs", "Pharmacy 1" });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "IdPharmacy", "ApiKeyPharmacy", "Endpoint", "NamePharmacy" },
                values: new object[] { "P2", "EFGH1234", "www.pharmacy2.rs", "Pharmacy 2" });
        }
    }
}
