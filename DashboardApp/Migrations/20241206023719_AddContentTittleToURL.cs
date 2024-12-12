using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardApp.Migrations
{
    public partial class AddContentTittleToURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentTittle",
                table: "URLs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentTittle",
                table: "URLs");
        }
    }
}
