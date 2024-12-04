using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailFromSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "1802040" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: null);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "25307000" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "24394400" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "24980450" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "1828225" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "23962000" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "22280111" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "24315555" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "22280222" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { null, "24987000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 1802040" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "");

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 25307000" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 24394400" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 24980450" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 1828225" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 23962000" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 22280111" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 24315555" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 22280222" });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "PhoneNumber" },
                values: new object[] { "", "+965 24987000" });
        }
    }
}
