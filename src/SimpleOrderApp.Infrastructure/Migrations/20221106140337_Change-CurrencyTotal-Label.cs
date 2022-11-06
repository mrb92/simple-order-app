using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class ChangeCurrencyTotalLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConvertedPricePerDay",
                table: "VehicleOrder",
                newName: "PriceInForeignCurrencyPerDay");

            migrationBuilder.RenameColumn(
                name: "ConvertedTotal",
                table: "Order",
                newName: "TotalInForeignCurrency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceInForeignCurrencyPerDay",
                table: "VehicleOrder",
                newName: "ConvertedPricePerDay");

            migrationBuilder.RenameColumn(
                name: "TotalInForeignCurrency",
                table: "Order",
                newName: "ConvertedTotal");
        }
    }
}
