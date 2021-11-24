using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_Class_Library.Migrations.MedicineDb
{
    public partial class MedicineContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineInventory",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInventory", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DosageInMilligrams = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    SideEffects = table.Column<List<string>>(nullable: false),
                    PossibleReactions = table.Column<List<string>>(nullable: false),
                    WayOfConsumption = table.Column<string>(nullable: false),
                    PotentialDangers = table.Column<string>(nullable: true),
                    IngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicine_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineCombination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstMedicineId = table.Column<int>(nullable: false),
                    SecondMedicineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCombination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineCombination_Medicine_FirstMedicineId",
                        column: x => x.FirstMedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineCombination_Medicine_SecondMedicineId",
                        column: x => x.SecondMedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_IngredientId",
                table: "Medicine",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCombination_FirstMedicineId",
                table: "MedicineCombination",
                column: "FirstMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCombination_SecondMedicineId",
                table: "MedicineCombination",
                column: "SecondMedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineCombination");

            migrationBuilder.DropTable(
                name: "MedicineInventory");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Ingredient");
        }
    }
}
