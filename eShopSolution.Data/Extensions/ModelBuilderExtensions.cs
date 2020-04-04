using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() 
                { 
                    Key = "HomeTitle", 
                    Value = "This is home page of EShopSolution" 
                },
                new AppConfig() 
                { 
                    Key = "HomeKeyword", 
                    Value = "This is keyword of EShopSolution" 
                },
                new AppConfig() 
                { 
                    Key = "HomeDescription", 
                    Value = "This is description of EShopSolution" 
                });

            modelBuilder.Entity<Language>().HasData(
                new Language()
                {
                    Id="vi-VN",
                    Name="Tiếng Việt",
                    IsDefault=true
                },
                new Language()
                {
                    Id = "en-US",
                    Name = "English",
                    IsDefault = false
                });

            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    Id = 1, IsShowOnHome = true,
                    ParentId = 1,
                    SortOders = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = 2,
                    SortOders = 2,
                    Status = Status.Active
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id=1,
                    CategoryId = 1,
                    Name = "Áo Nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm áo thời trang nam ",
                    SeoTitle = "Áo thời trang nam "
                },
                new CategoryTranslation()
                {
                    Id=2,
                    CategoryId = 1,
                    Name = "Men Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "men-shirt",
                    SeoDescription = "The shirt product for men",
                    SeoTitle = "The shirt for men "
                },
                new CategoryTranslation()
                {
                    Id=3,
                    CategoryId=2,
                    Name="Áo Nữ",
                    LanguageId="vi-VN",
                    SeoAlias="ao-nu",
                    SeoDescription="Sản phẩm áo thời trang nữ ",
                    SeoTitle="Áo thời trang nữ "
                },
                new CategoryTranslation()
                {
                    Id=4,
                    CategoryId = 2,
                    Name = "Women Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "women-shirt",
                    SeoDescription = "The shirt product for women",
                    SeoTitle = "The shirt for women "
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    ViewCount = 0,
                    Stock = 0                   
                });

            modelBuilder.Entity<ProductTransaction>().HasData(
                new ProductTransaction()
                {
                    Id=2,
                    ProductId=1,
                    Name="Áo sơ mi nam Việt Nam",
                    LanguageId="vi-VN",
                    SeoAlias="ao-so-mi-trang",
                    SeoDescription="Sản phẩm áo sơ mi nam ",
                    SeoTitle="Áo sơ mi nam ",
                    Details="Áo sơ mi",
                    Description="X,XL,XXL "
                },
                new ProductTransaction()
                {
                    Id=1,
                    ProductId=1,
                    Name="Men T-Shirt",
                    LanguageId="en-US",
                    SeoAlias="men-t-shirt",
                    SeoDescription="The T-shirt product for men",
                    SeoTitle="The T-shirt for men ",
                    Details="T-shirt for men",
                    Description=" X,XL,XXL"
                });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId=1,
                    CategoryId = 1
                });
            // any guid
            var roleId = new Guid("E605224E-1810-45C8-8846-8E180DBEDF48");
            var userId = new Guid("06F9348C-5BB8-45FF-9582-B85F23888510");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id=roleId,
                    Name="Admin",
                    NormalizedName="Admin",
                    Description="Administrator role"
                });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = userId,
                    UserName = "Admin",
                    NormalizedEmail = "Admin",
                    Email = "Supergoas@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123456789"),
                    SecurityStamp = String.Empty,
                    FristName = "Duong",
                    LastName = "Nguyen",
                    Dob = new DateTime(1999 / 04 / 26)
                }) ;
            // Sử dụng IdentityUserRole để gán Admin đấy vào Role ở trên
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId= roleId,
                    UserId= userId
                }
                );
        }
    }
}
