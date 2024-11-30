using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EnhanceApplicationForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "MeetsRequirements",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "Applications");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MeetsRequirements",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
