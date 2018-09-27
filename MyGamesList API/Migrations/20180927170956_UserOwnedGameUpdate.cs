using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGamesListAPI.Migrations
{
    public partial class UserOwnedGameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedGames_Users_UserId",
                table: "OwnedGames");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "OwnedGames",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedGames_Users_UserId",
                table: "OwnedGames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedGames_Users_UserId",
                table: "OwnedGames");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "OwnedGames",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedGames_Users_UserId",
                table: "OwnedGames",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
