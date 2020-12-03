using Microsoft.EntityFrameworkCore.Migrations;

namespace ITtrainees.DataAcces.Migrations
{
    public partial class DatabaseFrontEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                column: "Tag",
                value: "Python");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Articles");
        }
    }
}
