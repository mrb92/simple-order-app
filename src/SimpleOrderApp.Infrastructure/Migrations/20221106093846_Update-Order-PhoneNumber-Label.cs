using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    public partial class UpdateOrderPhoneNumberLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Order",
                newName: "CustomerPhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerPhoneNumber",
                table: "Order",
                newName: "PhoneNumber");
        }
    }
}
