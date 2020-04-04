using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace eShopSolution.Data.EF
{
    public class EShopDbContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
    {
        public EShopDbContext CreateDbContext(string[] args)
        {
            // Lấy từng config bằng cách tạo ra 1 configuaration mới
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // Sau khi Add tất cả file ở trên ta sẽ lấy được ConnectionString
            var connectionString = configuration.GetConnectionString("EShopSolutionDb");
            

            var optionsBuilder = new DbContextOptionsBuilder<EShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EShopDbContext(optionsBuilder.Options);
        }
    }
}
