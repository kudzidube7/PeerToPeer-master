using Microsoft.EntityFrameworkCore.Migrations;

namespace PeerToPeer.Migrations
{
    public partial class updateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Students_StudentId",
                table: "Donations");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Students_StudentId",
                table: "Donations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Students_StudentId",
                table: "Donations");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DonorId",
                table: "Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Students_StudentId",
                table: "Donations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
