using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGamesListAPI.Migrations
{
    public partial class UserWishlistItemRelationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_GameId",
                table: "WishlistItems",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Games_GameId",
                table: "WishlistItems",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Games_GameId",
                table: "WishlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WishlistItems_GameId",
                table: "WishlistItems");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
