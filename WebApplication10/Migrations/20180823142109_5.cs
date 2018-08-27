using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_ManagerUserId1",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_ManagerUserId1",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId1",
                table: "Department",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId1",
                table: "Department",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ManagerUserId",
                table: "Department",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerUserId1",
                table: "Department",
                column: "ManagerUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_ManagerUserId1",
                table: "Department",
                column: "ManagerUserId1",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
