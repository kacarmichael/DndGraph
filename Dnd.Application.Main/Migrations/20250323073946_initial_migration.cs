using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    AC = table.Column<int>(type: "integer", nullable: false),
                    StatsJson = table.Column<string>(type: "text", nullable: true),
                    ClassesJson = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AC", "ClassesJson", "Level", "Name", "StatsJson" },
                values: new object[] { 1, 10, "{}", 1, "Test Character", "{\"AbilityModifiers\":{\"Strength\":0,\"Dexterity\":0,\"Constitution\":0,\"Intelligence\":0,\"Wisdom\":0,\"Charisma\":0},\"AbilityScores\":{\"Strength\":10,\"Dexterity\":10,\"Constitution\":10,\"Intelligence\":10,\"Wisdom\":10,\"Charisma\":10},\"SkillModifiers\":{\"Acrobatics\":10,\"Animal Handling\":10,\"Arcana\":10,\"Athletics\":10,\"Deception\":10,\"History\":10,\"Insight\":10,\"Intimidation\":10,\"Investigation\":10,\"Medicine\":10,\"Nature\":10,\"Perception\":10,\"Performance\":10,\"Persuasion\":10,\"Religion\":10,\"Sleight of Hand\":10,\"Stealth\":10,\"Survival\":10},\"Proficiencies\":[]}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
