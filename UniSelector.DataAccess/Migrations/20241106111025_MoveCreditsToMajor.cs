using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MoveCreditsToMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Faculties");

            migrationBuilder.AddColumn<decimal>(
                name: "AveragePrice",
                table: "Majors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Majors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Majors");

            migrationBuilder.AddColumn<decimal>(
                name: "AveragePrice",
                table: "Faculties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
