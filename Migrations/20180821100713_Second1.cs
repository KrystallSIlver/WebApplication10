using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class Second1 : Migration
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
                name: "FK__User__CustomerId__2D27B809",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact__Custome__276EDEB3",
                table: "Contact",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Custo__32E0915F",
                table: "Department",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__User__CustomerId__2D27B809",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.SetNull);
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
                name: "FK__User__CustomerId__2D27B809",
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
                name: "FK__User__CustomerId__2D27B809",
                table: "User",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
