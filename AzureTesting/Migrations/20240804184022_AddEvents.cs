using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureTesting.Migrations
{
    /// <inheritdoc />
    public partial class AddEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EventSequence");

            migrationBuilder.CreateTable(
                name: "GameGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EventSequence]"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AssistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameGoals_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameGoals_Players_AssistId",
                        column: x => x.AssistId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameGoals_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameGoals_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GamePenalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [EventSequence]"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PenaltyType = table.Column<int>(type: "int", nullable: false),
                    Minutes = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePenalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePenalties_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GamePenalties_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GamePenalties_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGoals_AssistId",
                table: "GameGoals",
                column: "AssistId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoals_GameId",
                table: "GameGoals",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoals_PlayerId",
                table: "GameGoals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoals_TeamId",
                table: "GameGoals",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePenalties_GameId",
                table: "GamePenalties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePenalties_PlayerId",
                table: "GamePenalties",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePenalties_TeamId",
                table: "GamePenalties",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGoals");

            migrationBuilder.DropTable(
                name: "GamePenalties");

            migrationBuilder.DropSequence(
                name: "EventSequence");
        }
    }
}
