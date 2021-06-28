using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackTrace.Data.Migrations
{
    public partial class entitynames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Snacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Drinks");
        }
    }
}
