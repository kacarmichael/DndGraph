using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Auth.Migrations
{
    /// <inheritdoc />
    public partial class PasswordHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "public",
                table: "AuthUser",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                schema: "public",
                table: "AuthUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "asdf", "H8hleT+1SbqbVNmSnTXg9g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                schema: "public",
                table: "AuthUser");

            migrationBuilder.RenameColumn(
                name: "Salt",
                schema: "public",
                table: "AuthUser",
                newName: "Password");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "asdf");
        }
    }
}
