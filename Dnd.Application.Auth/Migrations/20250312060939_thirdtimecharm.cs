using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Application.Auth.Migrations
{
    /// <inheritdoc />
    public partial class thirdtimecharm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentSalt", "HashedPassword" },
                values: new object[] { "i69J0wAqt4Nbj6gzsffhsw==", "BjvZ7XTMzY86C7ZVCrbDqDGcj12o4NyjC0kvpcCORiI=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "AuthUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrentSalt", "HashedPassword" },
                values: new object[] { "D1GaeEs69JQ59TPg3qlBGg==", "RTYo7zOnb+DjfGTB/K6wsCrBK6R2PzGk9SgZ6fj+4kQ=" });
        }
    }
}
