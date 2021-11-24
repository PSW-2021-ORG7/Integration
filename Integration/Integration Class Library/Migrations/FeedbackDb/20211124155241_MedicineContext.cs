using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Class_Library.Migrations.FeedbackDb
{
    public partial class MedicineContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Response");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "IdFeedback");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Feedback");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "IdFeedback");
        }
    }
}
