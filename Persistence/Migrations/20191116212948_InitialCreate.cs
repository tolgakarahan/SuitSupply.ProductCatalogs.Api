using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalogs", x => x.Id);
                });
             
            migrationBuilder.InsertData(
                table: "ProductCatalogs",
                columns: new[] { "Id", "Code", "LastUpdate", "Name", "Photo", "Price" },
                values: new object[] { 1, "Suit_Black", null, "Black Suit", "http://pngimg.com/uploads/suit/suit_PNG8134.png", 140m });

            migrationBuilder.InsertData(
               table: "ProductCatalogs",
               columns: new[] { "Id", "Code", "LastUpdate", "Name", "Photo", "Price" },
               values: new object[] { 2, "Blue_Black", null, "Blue Suit", "http://pngimg.com/uploads/suit/suit_PNG8121.png", 150m });

            migrationBuilder.InsertData(
               table: "ProductCatalogs",
               columns: new[] { "Id", "Code", "LastUpdate", "Name", "Photo", "Price" },
               values: new object[] { 3, "Grey_Black", null, "Grey Suit", "http://pngimg.com/uploads/suit/suit_PNG8133.png", 160m });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalogs_Code",
                table: "ProductCatalogs",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCatalogs");
        }
    }
}
