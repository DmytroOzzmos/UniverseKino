using System;
using System.IO;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using UniverseKino.Data.EF;

namespace UniverseKino.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json");

            var connString = config.GetConnectionString("Develop");
            //var connString = root.GetConnectionString("Realese");

            var a = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(connString);

            builder.Register(c => new ApplicationContext(a.Options))
                .InstancePerDependency();
            //     .InstancePerLifetimeScope();

        }

    }
}