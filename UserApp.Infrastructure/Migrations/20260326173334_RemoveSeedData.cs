using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
    name: "Users",
    newName: "users");

            migrationBuilder.RenameIndex(
                name: "PK_Users",
                table: "users",
                newName: "PK_users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
    name: "PK_users",
    table: "users",
    newName: "PK_Users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");
        }
    }
}
