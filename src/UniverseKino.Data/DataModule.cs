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
using UniverseKino.Data.Entities;

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


            builder.Register(c =>
                {
                    var ctx = new UniverseKinoContext(
                 new DbContextOptionsBuilder<UniverseKinoContext>()
                .UseSqlServer(connString)
                .UseLazyLoadingProxies()
                .Options);
                    return ctx;
                })
                .As<UniverseKinoContext>();

            builder.RegisterType<CinemaHallRepository>()
                .As<ICinemaHallRepository>();

            builder.RegisterType<MovieRepository>()
                .As<IMovieRepository>();

            builder.RegisterType<ReservationRepository>()
                .As<IReservationRepository>();

            builder.RegisterType<SeatRepository>()
                .As<ISeatRepository>();

            builder.RegisterType<SessionRepository>()
                .As<ISessionRepository>();


            builder.RegisterType<AuthRepository>()
                .As<IAuthRepository>();
        }

    }
}