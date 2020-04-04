using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity","1,1");

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.SortOders).IsRequired();

            builder.Property(x => x.IsShowOnHome).IsRequired();
        }
    }

}
