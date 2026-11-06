using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class DBFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acces");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Warehouse",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Transfer",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ShipmentMethod",
                table: "Shipment",
                newName: "ShippingMethod");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Location",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Inventory",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Client",
                newName: "UpdatedAt");

            migrationBuilder.CreateTable(
                name: "Access",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ApiEndId = table.Column<int>(type: "integer", nullable: false),
                    CanGet = table.Column<bool>(type: "boolean", nullable: false),
                    CanPost = table.Column<bool>(type: "boolean", nullable: false),
                    CanPut = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => new { x.UserId, x.ApiEndId });
                    table.ForeignKey(
                        name: "FK_Access_ApiEnd_ApiEndId",
                        column: x => x.ApiEndId,
                        principalTable: "ApiEnd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Access_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ApiKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_ApiEndId",
                table: "Access",
                column: "ApiEndId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Warehouse",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Transfer",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "ShippingMethod",
                table: "Shipment",
                newName: "ShipmentMethod");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Location",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Inventory",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Client",
                newName: "UpdateAt");

            migrationBuilder.CreateTable(
                name: "Acces",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ApiEndId = table.Column<int>(type: "integer", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CanGet = table.Column<bool>(type: "boolean", nullable: false),
                    CanPost = table.Column<bool>(type: "boolean", nullable: false),
                    CanPut = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acces", x => new { x.UserId, x.ApiEndId });
                    table.ForeignKey(
                        name: "FK_Acces_ApiEnd_ApiEndId",
                        column: x => x.ApiEndId,
                        principalTable: "ApiEnd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acces_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ApiKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acces_ApiEndId",
                table: "Acces",
                column: "ApiEndId");
        }
    }
}
