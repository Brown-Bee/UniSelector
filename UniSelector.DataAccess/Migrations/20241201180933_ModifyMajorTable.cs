using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyMajorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinimumTOEFL",
                table: "Majors",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumIELTS",
                table: "Majors",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumGrade",
                table: "Majors",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "EmploymentRate",
                table: "Majors",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "AverageStartingSalary",
                table: "Majors",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AveragePrice",
                table: "Majors",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 15000.0, 800.0, 85.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14000.0, 750.0, 80.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14500.0, 780.0, 82.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 16000.0, 900.0, 90.0, 70.0, 6.0, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 16500.0, 950.0, 92.0, 70.0, 6.0, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 15500.0, 850.0, 88.0, 70.0, 6.0, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 13000.0, 650.0, 75.0, 65.0, 6.5, 90.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 12000.0, 600.0, 70.0, 60.0, null, null });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 12500.0, 550.0, 65.0, 60.0, 5.5, 75.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14000.0, 750.0, 85.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14500.0, 800.0, 80.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14200.0, 780.0, 82.0, 65.0, 6.5, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000.0, 1200.0, 92.0, 75.0, 6.5, 88.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000.0, 1150.0, 90.0, 75.0, 6.5, 88.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000.0, 1180.0, 91.0, 75.0, 6.5, 88.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000.0, 950.0, 88.0, 70.0, 6.5, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000.0, 900.0, 85.0, 70.0, 6.5, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000.0, 1000.0, 87.0, 70.0, 6.5, 85.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000.0, 850.0, 75.0, 70.0, 6.0, 82.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000.0, 870.0, 78.0, 70.0, 6.0, 82.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000.0, 860.0, 76.0, 70.0, 6.0, 82.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 18000.0, 700.0, 75.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 19000.0, 750.0, 80.0, 65.0, 6.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 18500.0, 730.0, 78.0, 65.0, 6.0, 80.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "MinimumTOEFL",
                table: "Majors",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MinimumIELTS",
                table: "Majors",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MinimumGrade",
                table: "Majors",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "EmploymentRate",
                table: "Majors",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageStartingSalary",
                table: "Majors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AveragePrice",
                table: "Majors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 15000m, 800m, 85f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14000m, 750m, 80f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14500m, 780m, 82f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 16000m, 900m, 90f, 70f, 6f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 16500m, 950m, 92f, 70f, 6f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 15500m, 850m, 88f, 70f, 6f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 13000m, 650m, 75f, 65f, 6.5f, 90f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 12000m, 600m, 70f, 60f, null, null });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 12500m, 550m, 65f, 60f, 5.5f, 75f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14000m, 750m, 85f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14500m, 800m, 80f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 14200m, 780m, 82f, 65f, 6.5f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000m, 1200m, 92f, 75f, 6.5f, 88f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000m, 1150m, 90f, 75f, 6.5f, 88f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 25000m, 1180m, 91f, 75f, 6.5f, 88f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000m, 950m, 88f, 70f, 6.5f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000m, 900m, 85f, 70f, 6.5f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 22000m, 1000m, 87f, 70f, 6.5f, 85f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000m, 850m, 75f, 70f, 6f, 82f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000m, 870m, 78f, 70f, 6f, 82f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 20000m, 860m, 76f, 70f, 6f, 82f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 18000m, 700m, 75f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 19000m, 750m, 80f, 65f, 6f, 80f });

            migrationBuilder.UpdateData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AveragePrice", "AverageStartingSalary", "EmploymentRate", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL" },
                values: new object[] { 18500m, 730m, 78f, 65f, 6f, 80f });
        }
    }
}
