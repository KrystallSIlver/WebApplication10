using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
