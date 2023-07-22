using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User.Management.API.Migrations
{
    /// <inheritdoc />
    public partial class addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1678f72b-b91e-46d3-ab86-cf202f4fbfe5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79cbc809-d17d-458e-b466-7263bc353ca3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bb221a8-d5be-41ca-ad70-c4d68be1a2c7", "1", "Staff", "Staff" },
                    { "7c2f929b-804d-4de5-ae5f-b5869df8416f", "2", "HR", "Human Resource" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb221a8-d5be-41ca-ad70-c4d68be1a2c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2f929b-804d-4de5-ae5f-b5869df8416f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1678f72b-b91e-46d3-ab86-cf202f4fbfe5", "2", "HR", "Human Resource" },
                    { "79cbc809-d17d-458e-b466-7263bc353ca3", "1", "Staff", "Staff" }
                });
        }
    }
}
