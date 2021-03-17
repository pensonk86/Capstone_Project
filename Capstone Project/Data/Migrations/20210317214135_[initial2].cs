using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duedate",
                table: "Finance");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Finance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Finance");

            migrationBuilder.AddColumn<int>(
                name: "Duedate",
                table: "Finance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
