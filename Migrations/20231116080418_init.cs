using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "Outfits",
                columns: table => new
                {
                    outfit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    outfit_type = table.Column<int>(type: "int", nullable: false),
                    outfit_brand_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outfit_no = table.Column<short>(type: "smallint", nullable: false),
                    player_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outfits", x => x.outfit_id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    player_id = table.Column<int>(type: "int", nullable: false),
                    player_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    player_age = table.Column<int>(type: "int", nullable: false),
                    player_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    outfit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.player_id);
                    table.ForeignKey(
                        name: "FK_Players_Branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Outfits_player_id",
                        column: x => x.player_id,
                        principalTable: "Outfits",
                        principalColumn: "outfit_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_team_id",
                        column: x => x.team_id,
                        principalTable: "Teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "branch_id", "branch_name" },
                values: new object[] { 1, "Football" });

            migrationBuilder.InsertData(
                table: "Outfits",
                columns: new[] { "outfit_id", "outfit_brand_name", "outfit_no", "player_id", "outfit_type" },
                values: new object[] { 1, "Adidas", (short)42, 1, 0 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "team_id", "team_name" },
                values: new object[] { 1, "Galatasaray" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "player_id", "player_age", "branch_id", "player_name", "outfit_id", "player_price", "team_id" },
                values: new object[] { 1, 30, 1, "Icardi", 1, 3000000m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_branch_id",
                table: "Players",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_team_id",
                table: "Players",
                column: "team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Outfits");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
