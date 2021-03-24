using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_Project.Data.Migrations
{
    public partial class migrationupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoalModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Monthly = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalModel");
        }
    }
}
