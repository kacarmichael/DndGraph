using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dnd.Application.Auth.Migrations
{
    /// <inheritdoc />
    public partial class new_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AuthUser",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    CurrentSalt = table.Column<string>(type: "text", nullable: false),
                    PreviousSalt = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    FailedLogins = table.Column<int>(type: "integer", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AuthUser",
                columns: new[] { "Id", "Created", "CurrentSalt", "Email", "FailedLogins", "HashedPassword", "LastLogin", "Locked", "PasswordResetToken", "PreviousSalt", "Role", "Updated", "Username" },
                values: new object[] { 1, new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), "G3tImxSKx40rt+8icDRRUQ==", "test@localhost", 0, "OtrJCwjXPRtgzgsnXXoTKsPrJazzwTxm6S2oSzssM2c=", new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), false, "Not Implemented Yet", "", "Admin", new DateTime(2000, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUser",
                schema: "public");
        }
    }
}
