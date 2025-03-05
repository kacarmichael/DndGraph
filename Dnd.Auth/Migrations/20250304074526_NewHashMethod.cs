using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Auth.Migrations
{
    /// <inheritdoc />
    public partial class NewHashMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "srnvZuXQabFO5XRaZrOA1oNjoL4J+Nwyxw4z9z6AYAc=", "YskO8jhgbB4LC8AyPJSzyA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "asdf", "H8hleT+1SbqbVNmSnTXg9g==" });
        }
    }
}
