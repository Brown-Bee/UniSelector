using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmploymentRateFromDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentRate",
                table: "Majors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EmploymentRate",
                table: "Majors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 5,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 6,
                column: "EmploymentRate",
                value: 82.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 7,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 8,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 9,
                column: "EmploymentRate",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 10,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 11,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 12,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 13,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 14,
                column: "EmploymentRate",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 15,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 16,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 17,
                column: "EmploymentRate",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 18,
                column: "EmploymentRate",
                value: 82.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 19,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 20,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 21,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 22,
                column: "EmploymentRate",
                value: 82.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 23,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 24,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 25,
                column: "EmploymentRate",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 26,
                column: "EmploymentRate",
                value: 83.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 27,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 28,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 29,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 30,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 31,
                column: "EmploymentRate",
                value: 78.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 32,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 33,
                column: "EmploymentRate",
                value: 82.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 34,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 35,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 36,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 37,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 38,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 39,
                column: "EmploymentRate",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 40,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 41,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 42,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 43,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 44,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 45,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 46,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 47,
                column: "EmploymentRate",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 48,
                column: "EmploymentRate",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 49,
                column: "EmploymentRate",
                value: 93.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 50,
                column: "EmploymentRate",
                value: 92.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 51,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 52,
                column: "EmploymentRate",
                value: 78.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 53,
                column: "EmploymentRate",
                value: 82.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 54,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 55,
                column: "EmploymentRate",
                value: 98.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 56,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 57,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 58,
                column: "EmploymentRate",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 59,
                column: "EmploymentRate",
                value: 95.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 60,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 61,
                column: "EmploymentRate",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 62,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 63,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 64,
                column: "EmploymentRate",
                value: 87.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 65,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 66,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 67,
                column: "EmploymentRate",
                value: 78.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 68,
                column: "EmploymentRate",
                value: 90.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 69,
                column: "EmploymentRate",
                value: 85.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 70,
                column: "EmploymentRate",
                value: 83.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 71,
                column: "EmploymentRate",
                value: 80.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 72,
                column: "EmploymentRate",
                value: 78.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 73,
                column: "EmploymentRate",
                value: 75.0);

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 74,
                column: "EmploymentRate",
                value: 75.0);
        }
    }
}
