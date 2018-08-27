using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class Second3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact__Custome",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Custo",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__CustomerId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact__Custome",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Custo",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Manag",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK__User__CustomerId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK__User__Department",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Manag",
                table: "Department",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__User__Department",
                table: "User",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
