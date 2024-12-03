using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddKUUniversityWithItsFacultiesAndMajors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Email", "FullDescription", "ImageUrl", "KuwaitRank", "Name", "PhoneNumber", "SmallDescription", "location", "type" },
                values: new object[] { 11, "", "Established in 1966, Kuwait's first public university offering comprehensive education across multiple campuses", "/images/University/KU.png", 1, "Kuwait University", "+965 24987000", "Kuwait's premier public higher education institution", "Multiple campuses - Main in Khaldiya", "Public" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "AdmissionRequirements", "Description", "StandardFacultyId", "UniversityId" },
                values: new object[,]
                {
                    { 21, "Minimum 80% in Scientific track, Aptitude test required", "Leading engineering programs with ABET accreditation", 1, 11 },
                    { 22, "Minimum 75% in Scientific track, Aptitude test required", "Research-focused science programs across multiple disciplines", 3, 11 },
                    { 23, "Minimum 90% in Scientific track, Aptitude test required", "Premier medical education in Kuwait", 2, 11 },
                    { 24, "Minimum 75% in Scientific track, Aptitude test required", "Healthcare professional programs with clinical training", 12, 11 },
                    { 25, "Minimum 85% in Scientific track, Aptitude test required", "PharmD program with extensive clinical training", 11, 11 },
                    { 26, "Minimum 85% in Scientific track, Aptitude test required", "Advanced dental education with modern facilities", 10, 11 },
                    { 27, "Minimum 75% in Either track, Aptitude test required", "AACSB-accredited business programs", 4, 11 },
                    { 28, "Minimum 70% in Either track, Aptitude test required", "Comprehensive humanities and social sciences programs", 5, 11 },
                    { 29, "Minimum 80% in Either track, Aptitude test required", "Kuwait's premier legal education program", 8, 11 },
                    { 30, "Minimum 70% in Either track, Aptitude test required", "Teacher preparation and educational research programs", 6, 11 },
                    { 31, "Minimum 70% in Either track, Aptitude test required", "Islamic studies and jurisprudence programs", 7, 11 }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "AveragePrice", "AverageStartingSalary", "Credits", "EmploymentRate", "FacultyId", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL", "RequiresAptitudeTest", "StandardMajorId" },
                values: new object[,]
                {
                    { 46, 0.0, 1200.0, 144, 90.0, 21, 80.0, null, null, true, 4 },
                    { 47, 0.0, 1200.0, 144, 92.0, 21, 80.0, null, null, true, 2 },
                    { 48, 0.0, 1300.0, 144, 95.0, 21, 80.0, null, null, true, 54 },
                    { 49, 0.0, 1250.0, 144, 93.0, 21, 80.0, null, null, true, 1 },
                    { 50, 0.0, 1200.0, 144, 92.0, 21, 80.0, null, null, true, 3 },
                    { 51, 0.0, 900.0, 132, 80.0, 22, 75.0, null, null, true, 12 },
                    { 52, 0.0, 850.0, 132, 78.0, 22, 75.0, null, null, true, 9 },
                    { 53, 0.0, 900.0, 132, 82.0, 22, 75.0, null, null, true, 10 },
                    { 54, 0.0, 850.0, 132, 80.0, 22, 75.0, null, null, true, 11 },
                    { 55, 0.0, 2000.0, 220, 98.0, 23, 90.0, null, null, true, 5 },
                    { 56, 0.0, 1100.0, 140, 90.0, 24, 75.0, null, null, true, 45 },
                    { 57, 0.0, 1000.0, 135, 88.0, 24, 75.0, null, null, true, 46 },
                    { 58, 0.0, 1500.0, 170, 95.0, 25, 85.0, null, null, true, 41 },
                    { 59, 0.0, 1800.0, 180, 95.0, 26, 85.0, null, null, true, 37 },
                    { 60, 0.0, 1100.0, 130, 90.0, 27, 75.0, null, null, true, 13 },
                    { 61, 0.0, 1200.0, 130, 88.0, 27, 75.0, null, null, true, 16 },
                    { 62, 0.0, 1000.0, 130, 85.0, 27, 75.0, null, null, true, 15 },
                    { 63, 0.0, 1000.0, 130, 85.0, 27, 75.0, null, null, true, 14 },
                    { 64, 0.0, 1100.0, 130, 87.0, 27, 75.0, null, null, true, 55 },
                    { 65, 0.0, 800.0, 128, 75.0, 28, 70.0, null, null, true, 18 },
                    { 66, 0.0, 850.0, 128, 80.0, 28, 70.0, null, null, true, 17 },
                    { 67, 0.0, 900.0, 128, 78.0, 28, 70.0, null, null, true, 77 },
                    { 68, 0.0, 1200.0, 138, 90.0, 29, 80.0, null, null, true, 29 },
                    { 69, 0.0, 900.0, 132, 85.0, 30, 70.0, null, null, true, 21 },
                    { 70, 0.0, 950.0, 132, 83.0, 30, 70.0, null, null, true, 66 },
                    { 71, 0.0, 850.0, 132, 80.0, 31, 70.0, null, null, true, 25 },
                    { 72, 0.0, 800.0, 132, 78.0, 31, 70.0, null, null, true, 26 },
                    { 73, 0.0, 800.0, 132, 75.0, 31, 70.0, null, null, true, 27 },
                    { 74, 0.0, 800.0, 132, 75.0, 31, 70.0, null, null, true, 28 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
