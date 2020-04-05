using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 22, 52, 39, 932, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 22, 16, 35, 117, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("e605224e-1810-45c8-8846-8e180dbedf48"), "bf1181c7-8496-4756-8e18-c2f5308074b2", "Administrator role", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"), new Guid("e605224e-1810-45c8-8846-8e180dbedf48") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FristName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"), 0, "80bb2a69-0296-49c2-9102-2045340c3e9b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(19), "Supergoas@gmail.com", true, "Duong", "Nguyen", false, null, "Admin", null, "AQAAAAEAACcQAAAAEKkf16X4XUtc9mN259keWnwdOa2MkkqPf1pxZceKMjTJPvjiXvAPpgWTnBXfEzRyxA==", null, false, "", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 4, 22, 52, 39, 945, DateTimeKind.Local).AddTicks(4431));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e605224e-1810-45c8-8846-8e180dbedf48"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"), new Guid("e605224e-1810-45c8-8846-8e180dbedf48") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 22, 16, 35, 117, DateTimeKind.Local).AddTicks(5548),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 4, 22, 52, 39, 932, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 4, 22, 16, 35, 129, DateTimeKind.Local).AddTicks(1882));
        }
    }
}
