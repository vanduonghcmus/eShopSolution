using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 22, 52, 39, 932, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDegault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 22, 52, 39, 932, DateTimeKind.Local).AddTicks(7945),
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e605224e-1810-45c8-8846-8e180dbedf48"),
                column: "ConcurrencyStamp",
                value: "bf1181c7-8496-4756-8e18-c2f5308074b2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("06f9348c-5bb8-45ff-9582-b85f23888510"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80bb2a69-0296-49c2-9102-2045340c3e9b", "AQAAAAEAACcQAAAAEKkf16X4XUtc9mN259keWnwdOa2MkkqPf1pxZceKMjTJPvjiXvAPpgWTnBXfEzRyxA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 4, 22, 52, 39, 945, DateTimeKind.Local).AddTicks(4431));
        }
    }
}
