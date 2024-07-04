using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePowerDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Power");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Power",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
