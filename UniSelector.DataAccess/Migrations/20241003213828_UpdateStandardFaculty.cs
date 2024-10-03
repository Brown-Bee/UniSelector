using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStandardFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_StandardFaculty_StandardFacultyId",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardFaculty",
                table: "StandardFaculty");

            migrationBuilder.RenameTable(
                name: "StandardFaculty",
                newName: "StandardFaculties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardFaculties",
                table: "StandardFaculties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_StandardFaculties_StandardFacultyId",
                table: "Faculties",
                column: "StandardFacultyId",
                principalTable: "StandardFaculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_StandardFaculties_StandardFacultyId",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardFaculties",
                table: "StandardFaculties");

            migrationBuilder.RenameTable(
                name: "StandardFaculties",
                newName: "StandardFaculty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardFaculty",
                table: "StandardFaculty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_StandardFaculty_StandardFacultyId",
                table: "Faculties",
                column: "StandardFacultyId",
                principalTable: "StandardFaculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
