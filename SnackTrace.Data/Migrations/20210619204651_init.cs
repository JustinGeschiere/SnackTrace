using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackTrace.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkMenu",
                columns: table => new
                {
                    DrinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkMenu", x => new { x.DrinksId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_DrinkMenu_Drinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSnack",
                columns: table => new
                {
                    MenusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnacksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSnack", x => new { x.MenusId, x.SnacksId });
                    table.ForeignKey(
                        name: "FK_MenuSnack_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSnack_Snacks_SnacksId",
                        column: x => x.SnacksId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkMenu_MenusId",
                table: "DrinkMenu",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSnack_SnacksId",
                table: "MenuSnack",
                column: "SnacksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkMenu");

            migrationBuilder.DropTable(
                name: "MenuSnack");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Snacks");
        }
    }
}
