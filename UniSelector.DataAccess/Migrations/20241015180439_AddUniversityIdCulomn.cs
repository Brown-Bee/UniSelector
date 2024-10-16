using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUniversityIdCulomn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnibersityId",
                table: "StudetsRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_UnibersityId",
                table: "StudetsRequests",
                column: "UnibersityId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudetsRequests_Universities_UnibersityId",
                table: "StudetsRequests",
                column: "UnibersityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudetsRequests_Universities_UnibersityId",
                table: "StudetsRequests");

            migrationBuilder.DropIndex(
                name: "IX_StudetsRequests_UnibersityId",
                table: "StudetsRequests");

            migrationBuilder.DropColumn(
                name: "UnibersityId",
                table: "StudetsRequests");
        }
    }
}
