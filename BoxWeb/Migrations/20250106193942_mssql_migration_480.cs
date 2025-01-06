using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxWeb.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_480 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubID);
                });

            migrationBuilder.CreateTable(
                name: "Refeeres",
                columns: table => new
                {
                    RefeereID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthsdayDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeeres", x => x.RefeereID);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthsdayDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachID);
                    table.ForeignKey(
                        name: "FK_Coaches_Clubs_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Clubs",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sportmen",
                columns: table => new
                {
                    SportsmanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthsdayDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubID = table.Column<int>(type: "int", nullable: true),
                    WeightCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achivments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportmen", x => x.SportsmanID);
                    table.ForeignKey(
                        name: "FK_Sportmen_Clubs_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Clubs",
                        principalColumn: "ClubID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefeereID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_Tournaments_Refeeres_RefeereID",
                        column: x => x.RefeereID,
                        principalTable: "Refeeres",
                        principalColumn: "RefeereID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    FightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(type: "int", nullable: true),
                    DateOfFight = table.Column<int>(type: "int", nullable: false),
                    BattleResult = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.FightID);
                    table.ForeignKey(
                        name: "FK_Fights_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SFs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FightID = table.Column<int>(type: "int", nullable: false),
                    SportsmanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SFs_Fights_FightID",
                        column: x => x.FightID,
                        principalTable: "Fights",
                        principalColumn: "FightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SFs_Sportmen_SportsmanID",
                        column: x => x.SportsmanID,
                        principalTable: "Sportmen",
                        principalColumn: "SportsmanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ClubID",
                table: "Coaches",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_TournamentID",
                table: "Fights",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_SFs_FightID",
                table: "SFs",
                column: "FightID");

            migrationBuilder.CreateIndex(
                name: "IX_SFs_SportsmanID",
                table: "SFs",
                column: "SportsmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Sportmen_ClubID",
                table: "Sportmen",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_RefeereID",
                table: "Tournaments",
                column: "RefeereID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "SFs");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Sportmen");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Refeeres");
        }
    }
}
