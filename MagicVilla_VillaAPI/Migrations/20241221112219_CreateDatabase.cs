using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "VillaNb_API",
                columns: table => new
                {
                    VillaNumber = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNb_API", x => x.VillaNumber);
                    table.ForeignKey(
                        name: "FK_VillaNb_API_Villas_API_VillaID",
                        column: x => x.VillaID,
                        principalTable: "Villas_API",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNb_API",
                columns: new[] { "VillaNumber", "CreatedDate", "SpecialDetails", "UpdatedDate", "VillaID" },
                values: new object[] { 1, new DateTime(2024, 12, 21, 12, 22, 17, 975, DateTimeKind.Local).AddTicks(5153), "Moknine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNb_API_VillaID",
                table: "VillaNb_API",
                column: "VillaID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNb_API");

            migrationBuilder.DropTable(
                name: "Villas_API");
        }
    }
}
