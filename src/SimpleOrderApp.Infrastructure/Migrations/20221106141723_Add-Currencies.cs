using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class AddCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RefCurrency",
                columns: new[] { "Id", "Name", "ShortName", "Symbol" },
                values: new object[] { 1, "Euro", "EUR", "€" });

            migrationBuilder.InsertData(
                table: "RefCurrency",
                columns: new[] { "Id", "Name", "ShortName", "Symbol" },
                values: new object[] { 2, "United States Dollar", "USD", "$" });

            migrationBuilder.InsertData(
                table: "RefCurrency",
                columns: new[] { "Id", "Name", "ShortName", "Symbol" },
                values: new object[] { 3, "Romanian Leu", "RON", "RON" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RefCurrency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefCurrency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefCurrency",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
