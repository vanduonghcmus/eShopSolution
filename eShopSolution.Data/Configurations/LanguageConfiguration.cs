﻿using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsUnicode(false).HasMaxLength(5).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

            builder.Property(x => x.IsDefault).IsRequired();
        }
    }
}
