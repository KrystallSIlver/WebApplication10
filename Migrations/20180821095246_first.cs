using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Department",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_ManagerId",
                table: "Department",
                newName: "IX_Department_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Department",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_UserId",
                table: "Department",
                newName: "IX_Department_ManagerId");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Department",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }
    }
}
