using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Mulher quase invisível", "Você quase não me vê" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Garoto Goma", "Flexibilidade é meu segundo nome" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Super quase voadora", "Sei pular, não sei voar" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Super Despercebido", "Sempre aqui, mas ninguém nota" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Super Ziguezague", "Nunca vou direto ao ponto" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Garota Eco", "Repito tudo, repito tudo" });
            migrationBuilder.InsertData("Hero", new string[] { "Name", "Slogan" }, new object[] { "Super Lento", "Chego lá, eventualmente" });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Hero");
        }
    }
}
