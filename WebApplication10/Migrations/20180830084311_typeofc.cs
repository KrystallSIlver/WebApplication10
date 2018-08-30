using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication10.Migrations
{
    public partial class typeofc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSchools",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Customer",
                nullable: false,
                defaultValue:"Business");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSchools",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Customer");
        }
    }
}
