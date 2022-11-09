using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HotelPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelPrices_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hotel 1" },
                    { 2, "Hotel 2" },
                    { 3, "Hotel 3" },
                    { 4, "Hotel 4" }
                });

            migrationBuilder.InsertData(
                table: "HotelPrices",
                columns: new[] { "Id", "Date", "HotelId", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50 },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50 },
                    { 3, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 60 },
                    { 4, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 65 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20 },
                    { 6, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25 },
                    { 7, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20 },
                    { 8, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 21 },
                    { 9, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 23 },
                    { 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 21 },
                    { 11, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20 },
                    { 12, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelPrices_HotelId",
                table: "HotelPrices",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelPrices");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
