using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ManagerUserId1",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department",
                column: "ManagerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ManagerUserId1",
                table: "Department",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department",
                column: "ManagerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
