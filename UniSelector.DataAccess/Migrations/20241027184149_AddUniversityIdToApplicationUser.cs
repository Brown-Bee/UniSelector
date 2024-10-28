using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUniversityIdToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniversityId",
                table: "AspNetUsers",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Universities_UniversityId",
                table: "AspNetUsers",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Universities_UniversityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudetsRequests_AspNetUsers_ApplicationUserId",
                table: "StudetsRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_StudetsRequests_Universities_UnibersityId",
                table: "StudetsRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudetsRequests",
                table: "StudetsRequests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniversityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KUAcademicAptitudeTests",
                table: "StudetsRequests");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UnibersityId",
                table: "StudetsRequests",
                newName: "UniversityId");

            migrationBuilder.RenameColumn(
                name: "TOEFL",
                table: "StudetsRequests",
                newName: "TOEFLScore");

            migrationBuilder.RenameColumn(
                name: "IELTS",
                table: "StudetsRequests",
                newName: "KUAptitudeTestScore");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "StudetsRequests",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "StudentRequestId",
                table: "StudetsRequests",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_StudetsRequests_UnibersityId",
                table: "StudetsRequests",
                newName: "IX_StudetsRequests_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_StudetsRequests_ApplicationUserId",
                table: "StudetsRequests",
                newName: "IX_StudetsRequests_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "StudetsRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudetsRequests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "StudetsRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "StudetsRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "IELTSScore",
                table: "StudetsRequests",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StudetsRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "StudetsRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "StudetsRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UniversityId1",
                table: "StudetsRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudetsRequests",
                table: "StudetsRequests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_FacultyId",
                table: "StudetsRequests",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_UniversityId1",
                table: "StudetsRequests",
                column: "UniversityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudetsRequests_AspNetUsers_UserId",
                table: "StudetsRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudetsRequests_Faculties_FacultyId",
                table: "StudetsRequests",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudetsRequests_Universities_UniversityId",
                table: "StudetsRequests",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudetsRequests_Universities_UniversityId1",
                table: "StudetsRequests",
                column: "UniversityId1",
                principalTable: "Universities",
                principalColumn: "Id");
        }
    }
}
