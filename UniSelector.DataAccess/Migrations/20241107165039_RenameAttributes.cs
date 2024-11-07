using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Universities",
                newName: "FullDescription");

            migrationBuilder.AddColumn<string>(
                name: "SmallDescription",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullDescription", "SmallDescription" },
                values: new object[] { "A leading open education institution in the Arab world.", "" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullDescription", "SmallDescription" },
                values: new object[] { "Offering American-style education with a Middle Eastern perspective.", "" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FullDescription", "SmallDescription" },
                values: new object[] { "Providing a comprehensive American liberal arts education.", "" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FullDescription", "SmallDescription" },
                values: new object[] { "The premier public institution of higher education in Kuwait.", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallDescription",
                table: "Universities");

            migrationBuilder.RenameColumn(
                name: "FullDescription",
                table: "Universities",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullDescription",
                value: null);
        }
    }
}
