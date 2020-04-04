﻿using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });

            builder.ToTable("ProductInCategory");

            builder.HasOne(x => x.Product).WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.ProductId);// Khóa ngoại cho productId

            builder.HasOne(x => x.Category).WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
