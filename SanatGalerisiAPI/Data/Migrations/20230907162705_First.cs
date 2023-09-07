using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SanatGalerisiAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tablolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RessamAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResminYapilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablolar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tablolar",
                columns: new[] { "Id", "ResminYapilmaTarihi", "RessamAdi" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ressam1" },
                    { 2, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ressam2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tablolar");
        }
    }
}
