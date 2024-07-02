using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Blazor.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabaseWithAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "UserRole" },
                values: new object[,]
                {
                    { "4de8a4ec-673e-4020-97c6-86c7c4faaf85", "ed42266d-0b60-4c9b-8df4-edc8b9a61753", "None", "NONE", 0 },
                    { "71c1a97f-e79f-4f3e-bdbb-20079f63c650", "68861903-fa05-43de-8462-dc7a1716691d", "Teacher", "TEACHER", 2 },
                    { "f0228a29-2106-4948-b8ee-34f4a15990be", "5c35a543-9cbd-47e8-a40d-69ecef4ac6fa", "Student", "STUDENT", 1 },
                    { "f50b5df3-e269-4dd1-bd4e-52bd212ea9f6", "4a278ef8-1f5c-4153-b484-87afa867dcbe", "Admin", "ADMIN", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ee9f4556-084a-4001-8648-53b2e18b1c1e", 0, "d26f1374-f66a-4931-82fe-ac4b85ff8733", "admin@admin.org", true, false, null, "ADMIN@ADMIN.ORG", "ADMIN@ADMIN.ORG", "AQAAAAIAAYagAAAAEMrJgJNHU3CX6bMh5Ra1WNjj6bfj4/PjkWNmXKdO8OsZwTBSu22Z1R7KBRfsJbXqaw==", null, false, "8726086f-4684-42ae-96f8-3215b7bd7248", false, "admin@admin.org" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f50b5df3-e269-4dd1-bd4e-52bd212ea9f6", "ee9f4556-084a-4001-8648-53b2e18b1c1e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4de8a4ec-673e-4020-97c6-86c7c4faaf85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71c1a97f-e79f-4f3e-bdbb-20079f63c650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0228a29-2106-4948-b8ee-34f4a15990be");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f50b5df3-e269-4dd1-bd4e-52bd212ea9f6", "ee9f4556-084a-4001-8648-53b2e18b1c1e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f50b5df3-e269-4dd1-bd4e-52bd212ea9f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee9f4556-084a-4001-8648-53b2e18b1c1e");

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
    }
}
