using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace User.Management.API.Migrations
{
    /// <inheritdoc />
    public partial class addroles1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "eb29035d-4f80-4f30-a528-7064df0247eb", "1", "Staff", "Staff" },
                    { "f23014f4-a460-419f-8d19-e1fced34f21a", "2", "HR", "Human Resource" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb29035d-4f80-4f30-a528-7064df0247eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f23014f4-a460-419f-8d19-e1fced34f21a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bb221a8-d5be-41ca-ad70-c4d68be1a2c7", "1", "Staff", "Staff" },
                    { "7c2f929b-804d-4de5-ae5f-b5869df8416f", "2", "HR", "Human Resource" }
                });
        }
    }
}
