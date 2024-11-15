using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToMajorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AverageStartingSalary",
                table: "Majors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "EmploymentRate",
                table: "Majors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MarketDemand",
                table: "Majors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MinimumGrade",
                table: "Majors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumIELTS",
                table: "Majors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MinimumTOEFL",
                table: "Majors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresAptitudeTest",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresBiology",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresChemistry",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresMath",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresScience",
                table: "Majors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageStartingSalary",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "EmploymentRate",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "MarketDemand",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "MinimumGrade",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "MinimumIELTS",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "MinimumTOEFL",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "RequiresAptitudeTest",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "RequiresBiology",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "RequiresChemistry",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "RequiresMath",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "RequiresScience",
                table: "Majors");
        }
    }
}
