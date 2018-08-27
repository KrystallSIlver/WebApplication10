using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class Manager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_ManagerUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_ManagerUserId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "User",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Department",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Department",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_UserId",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
