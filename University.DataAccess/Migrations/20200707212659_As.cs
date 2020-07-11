using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DataAccess.Migrations
{
    public partial class As : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Assignments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Assignments");
        }
    }
}
