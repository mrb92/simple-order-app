using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class CorrectVehicleIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Audi", "A4", 30m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "BMW", "3", 30m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Mercedes", "C", 30m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Toyota", "Corolla", 20m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Ford", "Transit", 35m, 2 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Volkswagen", "Transporter", 35m, 2 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Toyota", "Hilux", 35m, 1 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Volkswagen", "Amarok", 35m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Volkswagen", "Amarok", 35m, 1 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Toyota", "Hilux", 35m, 1 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Volkswagen", "Transporter", 35m, 2 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Ford", "Transit", 35m, 2 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Toyota", "Corolla", 20m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Mercedes", "C", 30m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "BMW", "3", 30m, 3 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[] { "Audi", "A4", 30m, 3 });
        }
    }
}
