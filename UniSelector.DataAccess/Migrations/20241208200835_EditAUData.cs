using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditAUData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/University/AU.png", "Australian University (AU)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/University/ACK.png", "Australian College of Kuwait (ACK)" });
        }
    }
}
