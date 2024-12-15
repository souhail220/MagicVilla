using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaTable1WithCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 55, 29, 407, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 55, 29, 407, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 55, 29, 407, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 55, 29, 407, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 55, 29, 407, DateTimeKind.Local).AddTicks(3976));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 51, 47, 304, DateTimeKind.Local).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 51, 47, 304, DateTimeKind.Local).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 51, 47, 304, DateTimeKind.Local).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 51, 47, 304, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 14, 19, 51, 47, 304, DateTimeKind.Local).AddTicks(4111));
        }
    }
}
