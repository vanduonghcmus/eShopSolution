using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfigs");// Chuyển sang bảng SQL với Name là: AppConfigs

            builder.HasKey(x=>x.Key);// Định nghĩa khóa chính

            builder.Property(x => x.Value).IsRequired(true);// Định nghĩa gtrị bắt phải nhập

        }
    }
}
