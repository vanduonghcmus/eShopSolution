using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Result).IsRequired();

            builder.Property(x =>  x.Status ).IsRequired();

            builder.Property(x => x.TransactionDate).IsRequired();

            builder.Property(x => x.Amount).IsRequired();

            builder.Property(x => x.Fee).IsRequired();
        }
    }
}
