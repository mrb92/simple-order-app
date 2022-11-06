using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class CorrectVehicleMakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -9,
                column: "Make",
                value: "Volkswagen");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -7,
                column: "Make",
                value: "Volkswagen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -9,
                column: "Make",
                value: "Volswagen");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -7,
                column: "Make",
                value: "Volswagen");
        }
    }
}
