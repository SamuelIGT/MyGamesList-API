using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGamesListAPI.Migrations
{
    public partial class AddDatabasePopulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            PopulateGame(migrationBuilder);
            PopulateUser(migrationBuilder);
            PopulateWishlistItem(migrationBuilder);
            PopulateOwnedGame(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Games");
            migrationBuilder.Sql("DELETE FROM Users");
            migrationBuilder.Sql("DELETE FROM WishlistItems");
            migrationBuilder.Sql("DELETE FROM OwnedGames");

        }

        private void PopulateGame(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("INSERT INTO Games(SteamAppid, Title, ShortDescription, DetailedDescription, HeaderImage, Price) VALUES(532210, 'Life is Strange 2', 'Os irmãos Sean e Daniel Diaz são obrigados a fugir de casa após um trágico incidente em Seattle. Com medo da polícia, os dois seguem em direção ao México, na tentativa de ocultar um repentino e misterioso poder sobrenatural.', 'Compre a Temporada Completa e receba o conjunto de patches \"Arcadia Bay\" para personalizar sua mochila no jogo. \nA premiada série Life is Strange volta com uma aguardada sequência da DONTNOD Entertainment. \nDois irmãos, Sean e Daniel Diaz, de 16 e 9 anos, respectivamente, são obrigados a fugir de casa após um trágico incidente em Seattle. Com medo da polícia, os dois seguem em direção ao México, na tentativa de ocultar um repentino e misterioso poder sobrenatural. \nA vida na estrada é difícil e, agora que é responsável pelo irmão pequeno, Sean se dá conta que suas decisões irão impactar a vida deles para sempre... \nO Episódio 1 estará disponível no dia 27 de setembro de 2018. Os episódios 2 a 5 estarão disponíveis em datas posteriores. \nA Temporada Completa inclui o Episódio 1 e o conjunto dos Episódios 2 a 5. Os Episódios 2 a 5 estarão disponíveis no lançamento.', 'https://steamcdn-a.akamaihd.net/steam/apps/532210/header.jpg?t=1537980377', 24.00)");
        }

        private void PopulateUser(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("INSERT INTO Users(Name, Email) VALUES('Samuel Alves', 'samuel.br.igt@gmail.com')");
        }

        private void PopulateWishlistItem(MigrationBuilder migrationBuilder) {
            string gameIdQuery = "(SELECT TOP 1 Id FROM Games)";
            string userIdQuery = "(SELECT TOP 1 Id FROM Users)";

            migrationBuilder.Sql($"INSERT INTO WishlistItems(RankPosition, GameId, UserId) VALUES(1, {gameIdQuery}, {userIdQuery})");

        }

        private void PopulateOwnedGame(MigrationBuilder migrationBuilder) {
            string gameIdQuery = "(SELECT TOP 1 Id FROM Games)";
            string userIdQuery = "(SELECT TOP 1 Id FROM Users)";

            migrationBuilder.Sql($"INSERT INTO OwnedGames(UserId, GameId, PlaytimeForever, PlaytimeTwoWeeks) VALUES({userIdQuery}, {gameIdQuery}, 12, 2)");
        }
    }
}
