using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class platform_migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterClasses_Characters_CharacterId",
                table: "CharacterClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacterCampaigns_Characters_CharacterId",
                table: "UserCharacterCampaigns");

            migrationBuilder.DropIndex(
                name: "IX_UserCharacterCampaigns_CharacterId",
                table: "UserCharacterCampaigns");

            migrationBuilder.DropColumn(
                name: "CharacterStatsId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Campaigns",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_OwnerId",
                table: "Campaigns",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_Id",
                table: "Campaigns",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Users_OwnerId",
                table: "Campaigns",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCharacterCampaigns_Users_UserId",
                table: "UserCharacterCampaigns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_Id",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Users_OwnerId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCharacterCampaigns_Users_UserId",
                table: "UserCharacterCampaigns");

            migrationBuilder.DropIndex(
                name: "IX_Characters_UserId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_OwnerId",
                table: "Campaigns");

            migrationBuilder.AddColumn<int>(
                name: "CharacterStatsId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Campaigns",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                name: "FK_UserCharacterCampaigns_Characters_CharacterId",
                table: "UserCharacterCampaigns",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
