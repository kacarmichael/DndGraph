using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dnd.Application.Auth.Migrations
{
    /// <inheritdoc />
    public partial class dbmigration2 : Migration
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
                values: new object[] { "D1GaeEs69JQ59TPg3qlBGg==", "RTYo7zOnb+DjfGTB/K6wsCrBK6R2PzGk9SgZ6fj+4kQ=" });
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
                values: new object[] { "G3tImxSKx40rt+8icDRRUQ==", "OtrJCwjXPRtgzgsnXXoTKsPrJazzwTxm6S2oSzssM2c=" });
        }
    }
}
