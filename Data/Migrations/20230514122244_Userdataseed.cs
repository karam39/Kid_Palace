using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class Userdataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9d4b26ff-f4fd-4071-b5c8-488cd0b10c2d", 0, "5ebd6b3d-77cb-4a78-a5df-0482fa40f4a7", "Admin786@gmail.com", true, false, null, "ADMIN786@GMAIL.COM", "ADMIN786@", "AQAAAAEAACcQAAAAEFGtqJilD57Kq/kozZHxkL2eJSJufl9jxXT5oqmVQFOX6+yO0p6qopF51pTc721GTA==", "1234567890", false, "dfe47ba7-a411-4a9c-9c22-f27fe633d803", false, "Admin786@" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d4b26ff-f4fd-4071-b5c8-488cd0b10c2d");
        }
    }
}
