using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA_Tracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayerStats_Games_GameID",
                table: "GamePlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayerStats_Players_PlayerID",
                table: "GamePlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_AwayTeamID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeTeamID",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "Players",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameColumn(
                name: "HomeTeamID",
                table: "Games",
                newName: "HomeTeamId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamID",
                table: "Games",
                newName: "AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamID",
                table: "Games",
                newName: "IX_Games_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamID",
                table: "Games",
                newName: "IX_Games_AwayTeamId");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "GamePlayerStats",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "GamePlayerStats",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayerStats_PlayerID",
                table: "GamePlayerStats",
                newName: "IX_GamePlayerStats_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayerStats_GameID",
                table: "GamePlayerStats",
                newName: "IX_GamePlayerStats_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayerStats_Games_GameId",
                table: "GamePlayerStats",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayerStats_Players_PlayerId",
                table: "GamePlayerStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayerStats_Games_GameId",
                table: "GamePlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayerStats_Players_PlayerId",
                table: "GamePlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Players",
                newName: "TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                newName: "IX_Players_TeamID");

            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "Games",
                newName: "HomeTeamID");

            migrationBuilder.RenameColumn(
                name: "AwayTeamId",
                table: "Games",
                newName: "AwayTeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                newName: "IX_Games_HomeTeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                newName: "IX_Games_AwayTeamID");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "GamePlayerStats",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GamePlayerStats",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayerStats_PlayerId",
                table: "GamePlayerStats",
                newName: "IX_GamePlayerStats_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayerStats_GameId",
                table: "GamePlayerStats",
                newName: "IX_GamePlayerStats_GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayerStats_Games_GameID",
                table: "GamePlayerStats",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayerStats_Players_PlayerID",
                table: "GamePlayerStats",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_AwayTeamID",
                table: "Games",
                column: "AwayTeamID",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeTeamID",
                table: "Games",
                column: "HomeTeamID",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
