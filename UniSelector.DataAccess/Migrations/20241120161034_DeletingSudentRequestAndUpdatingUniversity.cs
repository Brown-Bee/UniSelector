using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletingSudentRequestAndUpdatingUniversity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudetsRequests");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Universities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Universities",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "StudetsRequests",
                columns: table => new
                {
                    StudentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnibersityId = table.Column<int>(type: "int", nullable: false),
                    IELTS = table.Column<float>(type: "real", nullable: true),
                    KUAcademicAptitudeTests = table.Column<bool>(type: "bit", nullable: true),
                    TOEFL = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudetsRequests", x => x.StudentRequestId);
                    table.ForeignKey(
                        name: "FK_StudetsRequests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudetsRequests_Universities_UnibersityId",
                        column: x => x.UnibersityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Budget",
                value: 4500m);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Budget",
                value: 25000m);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Budget",
                value: 15000m);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Budget",
                value: 13000m);

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_ApplicationUserId",
                table: "StudetsRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_UnibersityId",
                table: "StudetsRequests",
                column: "UnibersityId");
        }
    }
}
