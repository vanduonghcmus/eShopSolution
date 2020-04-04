using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategory_Categories_CategotyId",
                table: "ProductInCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInCategory",
                table: "ProductInCategory");

            migrationBuilder.DropColumn(
                name: "SeoTitile",
                table: "ProductTransactionw");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategotyId",
                table: "ProductInCategory");

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "ProductTransactionw",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductInCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 15, 42, 6, 350, DateTimeKind.Local).AddTicks(19),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 4, 10, 15, 56, 330, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInCategory",
                table: "ProductInCategory",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of EShopSolution" },
                    { "HomeKeyword", "This is keyword of EShopSolution" },
                    { "HomeDescription", "This is description of EShopSolution" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOders", "Status" },
                values: new object[,]
                {
                    { 1, true, 1, 1, 1 },
                    { 2, true, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "OriginalPrice", "Price" },
                values: new object[] { 1, new DateTime(2020, 4, 4, 15, 42, 6, 358, DateTimeKind.Local).AddTicks(4920), 100000m, 200000m });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Áo Nam", "ao-nam", "Sản phẩm áo thời trang nam ", "Áo thời trang nam " },
                    { 3, 2, "vi-VN", "Áo Nữ", "ao-nu", "Sản phẩm áo thời trang nữ ", "Áo thời trang nữ " },
                    { 2, 1, "en-US", "Men Shirt", "men-shirt", "The shirt product for men", "The shirt for men " },
                    { 4, 2, "en-US", "Women Shirt", "women-shirt", "The shirt product for women", "The shirt for women " }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTransactionw",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 2, "X,XL,XXL ", "Áo sơ mi", "vi-VN", "Áo sơ mi nam Việt Nam", 1, "ao-so-mi-trang", "Sản phẩm áo sơ mi nam ", "Áo sơ mi nam " },
                    { 1, " X,XL,XXL", "T-shirt for men", "en-US", "Men T-Shirt", 1, "men-t-shirt", "The T-shirt product for men", "The T-shirt for men " }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategory_Categories_CategoryId",
                table: "ProductInCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategory_Categories_CategoryId",
                table: "ProductInCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInCategory",
                table: "ProductInCategory");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTransactionw",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTransactionw",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "ProductTransactionw");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductInCategory");

            migrationBuilder.AddColumn<string>(
                name: "SeoTitile",
                table: "ProductTransactionw",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategotyId",
                table: "ProductInCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 4, 10, 15, 56, 330, DateTimeKind.Local).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 4, 15, 42, 6, 350, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInCategory",
                table: "ProductInCategory",
                columns: new[] { "CategotyId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategory_Categories_CategotyId",
                table: "ProductInCategory",
                column: "CategotyId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
