using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DWFCxx.Migrations
{
    /// <inheritdoc />
    public partial class initialmodelandseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeatherSeason = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhiteGoals = table.Column<int>(type: "int", nullable: false),
                    BlueGoals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "WeatherSeason", "Year" },
                values: new object[,]
                {
                    { 1, "Spring", 2025 },
                    { 2, "Summer", 2025 },
                    { 3, "Autumn", 2025 },
                    { 4, "Winter", 2026 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "BlueGoals", "Date", "Round", "SeasonId", "WhiteGoals" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4 },
                    { 2, 3, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3 },
                    { 3, 5, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
