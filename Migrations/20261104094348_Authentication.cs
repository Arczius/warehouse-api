using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class Authentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiEnd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiEnd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ApiKey = table.Column<string>(type: "text", nullable: false),
                    App = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ApiKey);
                });

            migrationBuilder.CreateTable(
                name: "Acces",
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

            migrationBuilder.CreateIndex(
                name: "IX_ApiEnd_Name",
                table: "ApiEnd",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acces");

            migrationBuilder.DropTable(
                name: "ApiEnd");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
