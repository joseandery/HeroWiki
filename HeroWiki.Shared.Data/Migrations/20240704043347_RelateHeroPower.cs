using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateHeroPower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Power",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Power_HeroId",
                table: "Power",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Power_Hero_HeroId",
                table: "Power",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Power_Hero_HeroId",
                table: "Power");

            migrationBuilder.DropIndex(
                name: "IX_Power_HeroId",
                table: "Power");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Power");
        }
    }
}
