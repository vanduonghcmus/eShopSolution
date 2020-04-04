using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions"); 

            builder.HasKey(x =>x.Id).HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.FromDate).IsRequired();

            builder.Property(x => x.ToDate).IsRequired();

            builder.Property(x => x.ApplyForAll).IsRequired();

        }
    }
}
