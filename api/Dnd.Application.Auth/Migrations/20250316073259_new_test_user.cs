using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Application.Auth.Migrations
{
    /// <inheritdoc />
    public partial class new_test_user : Migration
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
                values: new object[] { "xAgPEpjAIRRqkGLmYnibFQ==", "ubRuRiajwISrw7X1+YOlqCMlX1Z3UlC40uiX7oTIrGM=" });
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
                values: new object[] { "i69J0wAqt4Nbj6gzsffhsw==", "BjvZ7XTMzY86C7ZVCrbDqDGcj12o4NyjC0kvpcCORiI=" });
        }
    }
}
