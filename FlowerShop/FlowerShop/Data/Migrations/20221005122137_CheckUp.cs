using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.Data.Migrations
{
    public partial class CheckUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "AddressIdByInfo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressIdByInfo",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
