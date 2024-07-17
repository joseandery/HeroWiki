using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateHeroLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroLeague",
                columns: table => new
                {
                    HerosId = table.Column<int>(type: "int", nullable: false),
                    LeaguesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroLeague", x => new { x.HerosId, x.LeaguesId });
                    table.ForeignKey(
                        name: "FK_HeroLeague_Hero_HerosId",
                        column: x => x.HerosId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroLeague_League_LeaguesId",
                        column: x => x.LeaguesId,
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroLeague_LeaguesId",
                table: "HeroLeague",
                column: "LeaguesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroLeague");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
