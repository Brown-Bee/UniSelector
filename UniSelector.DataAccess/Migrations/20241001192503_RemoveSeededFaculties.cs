using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeededFaculties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "AveragePrice", "Credits", "NameArabic", "NameEnglish", "UniversityId" },
                values: new object[,]
                {
                    { 1, 5000m, 130, "كلية الهندسة", "Engineering", 1 },
                    { 2, 8000m, 180, "كلية الطب", "Medicine", 2 },
                    { 3, 4500m, 120, "كلية إدارة الأعمال", "Business Administration", 3 },
                    { 4, 3500m, 125, "كلية العلوم", "Science", 4 }
                });
        }
    }
}
