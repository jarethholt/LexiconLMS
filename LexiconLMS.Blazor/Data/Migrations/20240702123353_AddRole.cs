using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1342f7c1-a736-42e1-a050-c8a8bb417579", "184276cb-4167-472b-9c33-7cb3c883ce96", "Admin", "ADMIN" },
                    { "943c5597-f06c-4fc0-95fa-ba0a78ab0fc0", "5ea93c2a-c046-4c8c-ac1c-56b3a1de0bc5", "Student", "STUDENT" },
                    { "aeb40f24-8379-4c6a-bc8e-6636b3f14645", "b74f27bb-3757-49ad-bb71-b11fdd60026b", "None", "NONE" },
                    { "faefdd44-558c-43d9-ab2c-6e8b89763eeb", "49808ff7-52bf-4363-92e6-9c7397aae040", "Teacher", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1342f7c1-a736-42e1-a050-c8a8bb417579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "943c5597-f06c-4fc0-95fa-ba0a78ab0fc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeb40f24-8379-4c6a-bc8e-6636b3f14645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faefdd44-558c-43d9-ab2c-6e8b89763eeb");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");
        }
    }
}
