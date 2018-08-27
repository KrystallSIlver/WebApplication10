using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact__Custome__276EDEB3",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Custo__32E0915F",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__CustomerId__2D27B809",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome__276EDEB3",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo__32E0915F",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId__2D27B809",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact__Custome__276EDEB3",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Custo__32E0915F",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__CustomerId__2D27B809",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "User",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome__276EDEB3",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo__32E0915F",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag__30F848ED",
                table: "Department",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId__2D27B809",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department__31EC6D26",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
