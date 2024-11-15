using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMajorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
