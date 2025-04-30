using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Main.Migrations
{
    /// <inheritdoc />
    public partial class add_stats_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats");

            migrationBuilder.DropIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CharacterStats",
                newName: "StatBlockId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Characters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterStats_Id",
                table: "Characters",
                column: "Id",
                principalTable: "CharacterStats",
                principalColumn: "StatBlockId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterStats_Id",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "StatBlockId",
                table: "CharacterStats",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Characters",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStats_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterStats_Characters_CharacterId",
                table: "CharacterStats",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
