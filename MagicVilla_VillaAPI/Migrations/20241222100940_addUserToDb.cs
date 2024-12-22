using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "VillaNb_API",
                keyColumn: "VillaNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 22, 11, 9, 39, 565, DateTimeKind.Local).AddTicks(6317));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "VillaNb_API",
                keyColumn: "VillaNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 16, 10, 27, 215, DateTimeKind.Local).AddTicks(541));
        }
    }
}
