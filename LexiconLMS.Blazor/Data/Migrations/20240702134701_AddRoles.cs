using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserRole" },
                values: new object[,]
                {
                    { "090c5245-27a3-47a0-b2fa-7a473423d47f", "3d5a8849-ccfc-4494-9a02-8d33ffa94622", "Teacher", "TEACHER", 2 },
                    { "11e0d5ef-b4eb-40cc-8193-51a5d1df2245", "ca846a42-7e4a-41c4-a604-06038aefaecb", "Admin", "ADMIN", 3 },
                    { "27c338ba-5812-42e1-a921-6e632268ecfe", "9f381c78-b933-4e88-8a79-487ab559b00b", "None", "NONE", 0 },
                    { "e1e23c37-9d4a-40ce-b871-1ed4add6a391", "150f9045-e3e9-41b1-806e-6fa401d041d2", "Student", "STUDENT", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090c5245-27a3-47a0-b2fa-7a473423d47f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11e0d5ef-b4eb-40cc-8193-51a5d1df2245");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27c338ba-5812-42e1-a921-6e632268ecfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e23c37-9d4a-40ce-b871-1ed4add6a391");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "AspNetRoles");
        }
    }
}
