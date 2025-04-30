using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    AC = table.Column<int>(type: "int", nullable: false),
                    StrengthScore = table.Column<int>(type: "integer", nullable: false),
                    DexterityScore = table.Column<int>(type: "integer", nullable: false),
                    ConstitutionScore = table.Column<int>(type: "integer", nullable: false),
                    IntelligenceScore = table.Column<int>(type: "integer", nullable: false),
                    WisdomScore = table.Column<int>(type: "integer", nullable: false),
                    CharismaScore = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AC", "CharismaScore", "ConstitutionScore", "DexterityScore", "IntelligenceScore", "Level", "Name", "StrengthScore", "WisdomScore" },
                values: new object[] { 1, 10, 10, 10, 10, 10, 1, "Test Character", 10, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
