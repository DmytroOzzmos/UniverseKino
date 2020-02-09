using Microsoft.EntityFrameworkCore.Design;
using UniverseKino.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace UniverseKino.Data.DesignDBConfigure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UniverseKinoContext>
    {
        public UniverseKinoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<UniverseKinoContext>();

            var connectionString = configuration.GetConnectionString("Develop");
            //var connectionString = configuration.GetConnectionString("Realese");

            builder.UseSqlServer(connectionString);

            return new UniverseKinoContext(builder.Options);
        }
    }
}
