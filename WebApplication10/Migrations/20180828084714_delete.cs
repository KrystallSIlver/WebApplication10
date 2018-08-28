using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class delete : Migration
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
                name: "FK__User__CustomerId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK__User__CustomerId",
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
                name: "FK__User__CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
