using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixKURank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11,
                column: "KuwaitRank",
                value: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11,
                column: "KuwaitRank",
                value: 1);
        }
    }
}
