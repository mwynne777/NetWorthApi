using Microsoft.EntityFrameworkCore.Migrations;

namespace NetWorth.Persistence.Migrations
{
    public partial class AddingContributionsandMaster_Factor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FactorID",
                table: "Liabilities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FactorID",
                table: "Assets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Amount = table.Column<double>(type: "money", nullable: false),
                    FactorID = table.Column<long>(nullable: false),
                    AssetId = table.Column<long>(nullable: true),
                    LiabilityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contributions_Liabilities_LiabilityId",
                        column: x => x.LiabilityId,
                        principalTable: "Liabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factor_Master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factor_Master", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_AssetId",
                table: "Contributions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_LiabilityId",
                table: "Contributions",
                column: "LiabilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "Factor_Master");

            migrationBuilder.DropColumn(
                name: "FactorID",
                table: "Liabilities");

            migrationBuilder.DropColumn(
                name: "FactorID",
                table: "Assets");
        }
    }
}
