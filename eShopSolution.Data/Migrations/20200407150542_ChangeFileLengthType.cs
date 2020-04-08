using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e605224e-1810-45c8-8846-8e180dbedf48"),
                column: "ConcurrencyStamp",
                value: "462c4d80-a39c-4f52-b36a-96dc3fc11db0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abc83f89-15d1-43ab-8989-4571af5d4140", "AQAAAAEAACcQAAAAEGt4UTMczrzzOc8XVgmvwdDhBQ7UuSa1+LtQi0eEKV4MGwwbroE8n8+W/QxNtwVNJA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 7, 22, 5, 41, 995, DateTimeKind.Local).AddTicks(5375));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e605224e-1810-45c8-8846-8e180dbedf48"),
                column: "ConcurrencyStamp",
                value: "5f1fb8a5-78cc-4a60-b038-c20f50552a29");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f701eb69-da0c-49f9-bb6c-0e8657da2dfd", "AQAAAAEAACcQAAAAEGs0dDtzHgIC3rmCdzvVHJhCC3keYck/Ff6uIwYs2q8bECwCODGV9dQjfSRbs1c5LQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 7, 14, 25, 27, 650, DateTimeKind.Local).AddTicks(5981));
        }
    }
}
