using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableToFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillasNb_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "VillasNb_API",
                keyColumn: "VillaNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 15, 5, 45, 473, DateTimeKind.Local).AddTicks(2305));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "VillasNb_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "VillasNb_API",
                keyColumn: "VillaNumber",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "Villas_API",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 22, 58, 8, 812, DateTimeKind.Local).AddTicks(1973));
        }
    }
}
