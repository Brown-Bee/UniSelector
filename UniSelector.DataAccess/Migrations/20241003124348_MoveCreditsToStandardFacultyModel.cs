using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoveCreditsToStandardFacultyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Faculties");

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "StandardFaculty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 1,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 2,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 3,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 4,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 5,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 6,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 7,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 8,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 9,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 10,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 11,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 12,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 13,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 14,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 15,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 16,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 17,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 18,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 19,
                column: "Credits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardFaculty",
                keyColumn: "Id",
                keyValue: 20,
                column: "Credits",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "StandardFaculty");

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
