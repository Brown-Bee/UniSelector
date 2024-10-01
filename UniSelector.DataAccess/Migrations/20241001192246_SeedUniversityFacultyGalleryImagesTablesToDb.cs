using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedUniversityFacultyGalleryImagesTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "ImageUrl", "UniversityId" },
                values: new object[,]
                {
                    { 1, "", 1 },
                    { 2, "", 1 },
                    { 3, "", 2 },
                    { 4, "", 3 },
                    { 5, "", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 4500m, "A leading open education institution in the Arab world.", "/images/University/AOU.png", "Arab Open University (AOU)" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 25000m, "Offering American-style education with a Middle Eastern perspective.", "/images/University/AUM.png", "American University In Middle East (AUM)" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 15000m, "Providing a comprehensive American liberal arts education.", "/images/University/AUK.png", "American University Of Kuwait (AUK)" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 13000m, "The premier public institution of higher education in Kuwait.", "/images/university/KU.png", "Kuwait University (KU)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 0m, "Good university", "", "Arab Open Universities" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 0m, "Good university", "", "American Universities In Middle East (AUM)" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 0m, "Good university", "", "American Universities Of Kuwait" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Budget", "Description", "ImageUrl", "Name" },
                values: new object[] { 0m, "Good university", "", "Kuwait Universities" });
        }
    }
}
