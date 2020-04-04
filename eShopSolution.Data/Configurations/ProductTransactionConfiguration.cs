using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    class ProductTransactionConfiguration : IEntityTypeConfiguration<ProductTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductTransaction> builder)
        {
            builder.ToTable("ProductTransactionw");
            builder.HasKey(x => x.Id ).HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ProductId).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Details).HasMaxLength(500);

            builder.Property(x => x.SeoAlias).HasMaxLength(200).IsRequired();

            builder.Property(x => x.LanguageId).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductTransactions).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Language).WithMany(x => x.ProductTransactions).HasForeignKey(x => x.LanguageId);
        }
    }
}
