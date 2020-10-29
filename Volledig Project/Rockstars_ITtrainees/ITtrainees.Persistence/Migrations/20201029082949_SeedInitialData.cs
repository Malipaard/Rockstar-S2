using Microsoft.EntityFrameworkCore.Migrations;

namespace ITtrainees.DataAcces.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Author", "Summary", "Title" },
                values: new object[] { 1, "Sem", "Description of the article", "First Article" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1);
        }
    }
}
