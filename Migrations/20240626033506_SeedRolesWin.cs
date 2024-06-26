using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesWin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07be8619-393c-46d4-ac11-e06701941e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d63e069-798b-415c-a4b3-f307b31d503c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d15f2341-a9d6-4443-a1eb-d0a6805c956a", null, "User", "USER" },
                    { "d963bf7d-5368-4e25-90b3-f0bb4504b9f4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15f2341-a9d6-4443-a1eb-d0a6805c956a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d963bf7d-5368-4e25-90b3-f0bb4504b9f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07be8619-393c-46d4-ac11-e06701941e00", null, "Admin", "ADMIN" },
                    { "2d63e069-798b-415c-a4b3-f307b31d503c", null, "User", "USER" }
                });
        }
    }
}
