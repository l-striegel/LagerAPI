using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStylesJsonToArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StylesJson",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "{}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StylesJson",
                table: "Articles");
        }
    }
}
