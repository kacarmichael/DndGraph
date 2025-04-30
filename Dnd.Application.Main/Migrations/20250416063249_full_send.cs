using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class full_send : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClass_Characters_CharacterId",
                table: "CharacterClass");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterStats_Id",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterClass",
                table: "CharacterClass");

            migrationBuilder.RenameTable(
                name: "CharacterClass",
                newName: "CharacterClasses");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Characters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterClasses",
                table: "CharacterClasses",
                columns: new[] { "CharacterId", "ClassId" });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    DungeonMasterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    RollType = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    Ability = table.Column<string>(type: "text", nullable: true),
                    Modifier = table.Column<int>(type: "integer", nullable: true),
                    SavingThrowRoll_Ability = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCharacterCampaigns",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    CampaignId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharacterCampaigns", x => new { x.UserId, x.CharacterId, x.CampaignId });
                    table.ForeignKey(
                        name: "FK_UserCharacterCampaigns_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthUserId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCharacterCampaigns_CharacterId",
                table: "UserCharacterCampaigns",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClasses_Characters_CharacterId",
                table: "CharacterClasses",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClasses_Characters_CharacterId",
                table: "CharacterClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CampaignSessions");

            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropTable(
                name: "UserCharacterCampaigns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterClasses",
                table: "CharacterClasses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "CharacterClasses",
                newName: "CharacterClass");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Characters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterClass",
                table: "CharacterClass",
                columns: new[] { "CharacterId", "ClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterClass_Characters_CharacterId",
                table: "CharacterClass",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterStats_Id",
                table: "Characters",
                column: "Id",
                principalTable: "CharacterStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
