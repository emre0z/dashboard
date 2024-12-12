using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardApp.Migrations
{
    public partial class AddCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infos_SubTopics_SubTopicId",
                table: "Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_URLs_SubTopics_SubTopicId",
                table: "URLs");

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_SubTopics_SubTopicId",
                table: "Infos",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_URLs_SubTopics_SubTopicId",
                table: "URLs",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Infos_SubTopics_SubTopicId",
                table: "Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_URLs_SubTopics_SubTopicId",
                table: "URLs");

            migrationBuilder.AddForeignKey(
                name: "FK_Infos_SubTopics_SubTopicId",
                table: "Infos",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_URLs_SubTopics_SubTopicId",
                table: "URLs",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");
        }
    }
}
