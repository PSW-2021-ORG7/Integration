using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Class_Library.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    IdPharmacy = table.Column<string>(nullable: false),
                    NamePharmacy = table.Column<string>(nullable: true),
                    ApiKeyPharmacy = table.Column<string>(nullable: true),
                    Endpoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.IdPharmacy);
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "IdPharmacy", "ApiKeyPharmacy", "Endpoint", "NamePharmacy" },
                values: new object[,]
                {
                    { "P1", "ABCD1234", "www.pharmacy1.rs", "Pharmacy 1" },
                    { "P2", "EFGH1234", "www.pharmacy2.rs", "Pharmacy 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
