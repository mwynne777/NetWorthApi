using Microsoft.EntityFrameworkCore.Migrations;

namespace NetWorth.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    CurrentValue = table.Column<double>(type: "money", nullable: false),
                    HasInterest = table.Column<bool>(maxLength: 1, nullable: false),
                    InterestRate = table.Column<double>(type: "decimal", nullable: false),
                    Type = table.Column<int>(maxLength: 2, nullable: false),
                    UserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Users",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liabilities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    CurrentValue = table.Column<double>(type: "money", nullable: false),
                    HasInterest = table.Column<bool>(maxLength: 1, nullable: false),
                    InterestRate = table.Column<double>(type: "decimal", nullable: false),
                    Type = table.Column<int>(maxLength: 2, nullable: false),
                    UserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liabilities_Users",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Liabilities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
