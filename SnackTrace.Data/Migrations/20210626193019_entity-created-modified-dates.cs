using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackTrace.Data.Migrations
{
    public partial class entitycreatedmodifieddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Snacks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Snacks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Drinks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Drinks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Drinks");
        }
    }
}
