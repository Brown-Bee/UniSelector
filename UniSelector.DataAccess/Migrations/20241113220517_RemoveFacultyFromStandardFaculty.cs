using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFacultyFromStandardFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_StandardFacultyId",
                table: "Faculties");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_StandardFacultyId",
                table: "Faculties",
                column: "StandardFacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_StandardFacultyId",
                table: "Faculties");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_StandardFacultyId",
                table: "Faculties",
                column: "StandardFacultyId",
                unique: true);
        }
    }
}
