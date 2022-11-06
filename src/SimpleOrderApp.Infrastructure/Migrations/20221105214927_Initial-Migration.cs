using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefOrderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefOrderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefVehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefVehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ToCurrencyId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_RefCurrency_From",
                        column: x => x.FromCurrencyId,
                        principalTable: "RefCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_RefCurrency_To",
                        column: x => x.ToCurrencyId,
                        principalTable: "RefCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ConvertedTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_RefCurrency",
                        column: x => x.CurrencyId,
                        principalTable: "RefCurrency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_RefOrderType",
                        column: x => x.OrderTypeId,
                        principalTable: "RefOrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_RefVehicle",
                        column: x => x.TypeId,
                        principalTable: "RefVehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsTankFull = table.Column<bool>(type: "bit", nullable: true),
                    IsCarIntact = table.Column<bool>(type: "bit", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ConvertedPricePerDay = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleOrder_Order",
                        column: x => x.Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleOrder_Vehicle",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RefOrderType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Vehicles" });

            migrationBuilder.InsertData(
                table: "RefVehicleType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Truck" },
                    { 2, "Minivan" },
                    { 3, "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Make", "Model", "PricePerDay", "TypeId" },
                values: new object[,]
                {
                    { -9, "Volswagen", "Amarok", 35m, 1 },
                    { -8, "Toyota", "Hilux", 35m, 1 },
                    { -7, "Volswagen", "Transporter", 35m, 2 },
                    { -6, "Ford", "Transit", 35m, 2 },
                    { -5, "Volkswagen", "Golf", 20m, 3 },
                    { -4, "Toyota", "Corolla", 20m, 3 },
                    { -3, "Mercedes", "C", 30m, 3 },
                    { -2, "BMW", "3", 30m, 3 },
                    { -1, "Audi", "A4", 30m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_FromCurrencyId",
                table: "CurrencyRate",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_ToCurrencyId",
                table: "CurrencyRate",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CurrencyId",
                table: "Order",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeId",
                table: "Vehicle",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOrder_VehicleId",
                table: "VehicleOrder",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRate");

            migrationBuilder.DropTable(
                name: "VehicleOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "RefCurrency");

            migrationBuilder.DropTable(
                name: "RefOrderType");

            migrationBuilder.DropTable(
                name: "RefVehicleType");
        }
    }
}
