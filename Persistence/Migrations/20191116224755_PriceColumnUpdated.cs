using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PriceColumnUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductCatalogs",
                type: "decimal(18,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductCatalogs",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)");
        }
    }
}
