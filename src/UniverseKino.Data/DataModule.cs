using System.Net.Mime;
using System;
using System.IO;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using UniverseKino.Data.EF;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.Repositories;

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

            var connString = config.GetConnectionString("Develop");
            //var connString = root.GetConnectionString("Realese");

            var appContext = new ApplicationContext(
                 new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(connString)
                .Options
                );

            var dbContext = new UniverseKinoContext(
                 new DbContextOptionsBuilder<UniverseKinoContext>()
                .UseSqlServer(connString)
                .Options
                );


            builder.RegisterInstance(appContext).As<ApplicationContext>();
            // builder.Register(c => new ApplicationContext(appContext.Options))
            //     .InstancePerDependency();

            //builder.RegisterInstance(dbContext).As<UniverseKinoContext>();

            builder.Register(c => new UniverseKinoContext(
                 new DbContextOptionsBuilder<UniverseKinoContext>()
                .UseSqlServer(connString)
                .Options
                ))
            .InstancePerDependency();

            builder.Register(u => new UnitOfWork(u.Resolve<UniverseKinoContext>()))
            .As<IUnitOfWorkEntities>()
            .InstancePerDependency();


        }

    }
}