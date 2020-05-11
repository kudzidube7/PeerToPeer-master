using Microsoft.EntityFrameworkCore.Migrations;

namespace PeerToPeer.Migrations
{
    public partial class insertGoalReached : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGoalReached",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGoalReached",
                table: "Students");
        }
    }
}
