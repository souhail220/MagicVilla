using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CheckMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNb_API",
                keyColumn: "VillaNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(4757));
        }
    }
}
