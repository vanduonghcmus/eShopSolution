using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.Id).HasAnnotation("SqlServer:Identity", "1,1");

            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Message).IsRequired();
        }
    }
}
