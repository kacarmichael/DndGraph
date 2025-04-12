using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class remove_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassesJson",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StatsJson",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Stats",
                table: "Characters",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Stats",
                value: "{\"Level\":1,\"Abilities\":[{\"Name\":\"Strength\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[\"Athletics\"]},{\"Name\":\"Dexterity\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[\"Acrobatics\",\"Stealth\",\"SleightOfHand\"]},{\"Name\":\"Constitution\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[]},{\"Name\":\"Intelligence\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[\"Arcana\",\"History\",\"Investigation\",\"Nature\",\"Religion\"]},{\"Name\":\"Wisdom\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[\"AnimalHandling\",\"Insight\",\"Medicine\",\"Perception\",\"Survival\"]},{\"Name\":\"Charisma\",\"Score\":10,\"Modifier\":0,\"Proficient\":false,\"Skills\":[\"Deception\",\"Intimidation\",\"Performance\",\"Persuasion\"]}],\"Skills\":[{\"Name\":\"Acrobatics\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"AnimalHandling\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Arcana\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Athletics\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Deception\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"History\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Insight\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Intimidation\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Investigation\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Medicine\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Nature\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Perception\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Performance\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Persuasion\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Religion\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"SleightOfHand\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Stealth\",\"Modifier\":0,\"Proficient\":false},{\"Name\":\"Survival\",\"Modifier\":0,\"Proficient\":false}],\"ProficiencyBonus\":2}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stats",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "ClassesJson",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatsJson",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassesJson", "StatsJson" },
                values: new object[] { "{}", "{\"AbilityModifiers\":{\"Strength\":0,\"Dexterity\":0,\"Constitution\":0,\"Intelligence\":0,\"Wisdom\":0,\"Charisma\":0},\"AbilityScores\":{\"Strength\":10,\"Dexterity\":10,\"Constitution\":10,\"Intelligence\":10,\"Wisdom\":10,\"Charisma\":10},\"SkillModifiers\":{\"Acrobatics\":10,\"Animal Handling\":10,\"Arcana\":10,\"Athletics\":10,\"Deception\":10,\"History\":10,\"Insight\":10,\"Intimidation\":10,\"Investigation\":10,\"Medicine\":10,\"Nature\":10,\"Perception\":10,\"Performance\":10,\"Persuasion\":10,\"Religion\":10,\"Sleight of Hand\":10,\"Stealth\":10,\"Survival\":10},\"Proficiencies\":[]}" });
        }
    }
}
