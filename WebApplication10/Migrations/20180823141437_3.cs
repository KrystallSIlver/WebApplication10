using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerUserId",
                table: "Department",
                column: "ManagerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department",
                column: "ManagerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_ManagerUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "Department");
        }
    }
}
