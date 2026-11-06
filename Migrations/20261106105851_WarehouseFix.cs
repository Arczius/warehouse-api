using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class WarehouseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Warehouse",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CommodityCode",
                table: "Item",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Warehouse");

            migrationBuilder.AlterColumn<string>(
                name: "CommodityCode",
                table: "Item",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
