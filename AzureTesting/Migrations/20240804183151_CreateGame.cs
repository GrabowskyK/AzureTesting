using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureTesting.Migrations
{
    /// <inheritdoc />
    public partial class CreateGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAID = table.Column<int>(type: "int", nullable: false),
                    TeamBID = table.Column<int>(type: "int", nullable: false),
                    ScoreTeamA = table.Column<int>(type: "int", nullable: false),
                    ScoreTeamB = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamAID",
                        column: x => x.TeamAID,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamBID",
                        column: x => x.TeamBID,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamAID",
                table: "Games",
                column: "TeamAID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamBID",
                table: "Games",
                column: "TeamBID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
