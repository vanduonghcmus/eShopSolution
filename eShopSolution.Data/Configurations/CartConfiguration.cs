using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x=>x.Id).HasAnnotation("SqlServer:Identity","1,1");

            builder.HasOne(z => z.Product).WithMany(z => z.Carts).HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.DateCreated).IsRequired();
        }
    }
}
