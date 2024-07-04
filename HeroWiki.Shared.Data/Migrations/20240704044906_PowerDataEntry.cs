using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class PowerDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Power", new string[] { "Name", "Strength", "HeroId" }, new object[] { "Quase Invisível", 5, 4 });
            migrationBuilder.InsertData("Power", new string[] { "Name", "Strength", "HeroId" }, new object[] { "Desaparecimento Social", 6, 4 });
            migrationBuilder.InsertData("Power", new string[] { "Name", "Strength", "HeroId" }, new object[] { "Desvio Mestre", 7, 5 });
            migrationBuilder.InsertData("Power", new string[] { "Name", "Strength", "HeroId" }, new object[] { "Devagar e Sempre", 4, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
