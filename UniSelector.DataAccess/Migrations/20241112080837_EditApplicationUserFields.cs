using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditApplicationUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameInArabic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NameInEnglish",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HighSchoolAverage",
                table: "AspNetUsers",
                newName: "TOEFL");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublicSchool",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "HasFourYearExperience",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "HasAptitudeTest",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "IELTS",
                table: "AspNetUsers",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAptitudeTest",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IELTS",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TOEFL",
                table: "AspNetUsers",
                newName: "HighSchoolAverage");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublicSchool",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasFourYearExperience",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameInArabic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameInEnglish",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
