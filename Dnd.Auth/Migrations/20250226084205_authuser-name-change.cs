using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Auth.Migrations
{
    /// <inheritdoc />
    public partial class authusernamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "AuthUser",
                newName: "AuthUser",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AuthUser",
                schema: "public",
                newName: "AuthUser");
        }
    }
}
