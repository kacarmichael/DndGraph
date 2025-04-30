using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpellcastingAbility = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name", "SpellcastingAbility" },
                values: new object[,]
                {
                    { 1, "Barbarian", "Strength" },
                    { 2, "Bard", "Charisma" },
                    { 3, "Cleric", "Wisdom" },
                    { 4, "Druid", "Wisdom" },
                    { 5, "Fighter", "Strength" },
                    { 6, "Monk", "Dexterity" },
                    { 7, "Paladin", "Charisma" },
                    { 8, "Ranger", "Dexterity" },
                    { 9, "Rogue", "Dexterity" },
                    { 10, "Sorcerer", "Charisma" },
                    { 11, "Warlock", "Charisma" },
                    { 12, "Wizard", "Intelligence" },
                    { 13, "Artificer", "Intelligence" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
