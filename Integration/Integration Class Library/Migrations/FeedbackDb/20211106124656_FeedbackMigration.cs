using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Class_Library.Migrations.FeedbackDb
{
    public partial class FeedbackMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    IdFeedback = table.Column<string>(nullable: false),
                    IdPharmacy = table.Column<string>(nullable: false),
                    ContentFeedback = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.IdFeedback);
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "IdFeedback", "ContentFeedback", "IdPharmacy" },
                values: new object[] { "F1", "This hospital sucks", "P2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
