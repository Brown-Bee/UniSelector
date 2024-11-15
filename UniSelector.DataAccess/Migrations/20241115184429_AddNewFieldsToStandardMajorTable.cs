using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToStandardMajorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CareerOptions",
                table: "StandardMajors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StandardMajors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighSchoolPath",
                table: "StandardMajors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudyDuration",
                table: "StandardMajors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerOptions",
                table: "StandardMajors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StandardMajors");

            migrationBuilder.DropColumn(
                name: "HighSchoolPath",
                table: "StandardMajors");

            migrationBuilder.DropColumn(
                name: "StudyDuration",
                table: "StandardMajors");
        }
    }
}
