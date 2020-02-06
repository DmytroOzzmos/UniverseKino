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
        protected void OnModelCreating(UniverseKinoContext ctx)
        {
            InitDb init = new InitDb();

            ctx.CinemaHalls.AddRange(
                new CinemaHall[]
                    {
                        new CinemaHall { Number = 1, Id = 1, Seats = init.GetSeats(10, 10, 100, 1) },
                        new CinemaHall { Number = 2, Id = 2, Seats = init.GetSeats(10, 10, 150, 2) },
                        new CinemaHall { Number = 3, Id = 3, Seats = init.GetSeats(13, 13, 200, 3) },
                        new CinemaHall { Number = 4, Id = 4, Seats = init.GetSeats(10, 10, 177, 4) },
                    }
            );


            ctx.Movies.AddRange(
                new Movie[]
                {
                    new Movie {Id = 1, Name = "Movie1", Genre = "FantastikaBlya", Duration = 100  },
                    new Movie {Id = 2, Name = "Second movie ska", Genre = "TravelYopta", Duration = 187  },
                    new Movie {Id = 3, Name = "LastNah", Genre = "Ujastik", Duration = 250 },
                }
            );


            ctx.Sessions.AddRange(
                new Session[]
                 {
                        new Session {Id = 1, Date = GetDate(1, 9), MovieId = 1, CinemaHallId = 1 },
                        new Session {Id = 2, Date = GetDate(3, 9), MovieId = 1, CinemaHallId = 3 },
                        new Session {Id = 3, Date = GetDate(5, 9), MovieId = 1, CinemaHallId = 3 },
                        new Session {Id = 4, Date = GetDate(1, 12), MovieId = 2, CinemaHallId = 1 },
                }
            );

            ctx.SaveChanges();

        }
        private static DateTime GetDate(int day = 0, int hour = 8)
        {
            var dateString = (new DateTime()).AddDays(day).ToShortDateString();
            var date = DateTime.Parse(dateString);
            date.AddHours(hour);
            return date;

        }
        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connString = config.GetConnectionString("Develop");
            //var connString = root.GetConnectionString("Realese");


            //var dbContext = new UniverseKinoContext(
            //     new DbContextOptionsBuilder<UniverseKinoContext>()
            //    .UseSqlServer(connString)
            //    .Options
            //    );


            // builder.Register(ctx => new ApplicationContext(

            builder.Register(c =>
                {
                    var ctx = new UniverseKinoContext(
                 new DbContextOptionsBuilder<UniverseKinoContext>()
                .UseSqlServer(connString)
                .Options);
                    return ctx;
                }
                )
                .As<UniverseKinoContext>();
            // .InstancePerDependency();


            builder.RegisterType<AuthRepository>();
            // .InstancePerDependency();


            builder.Register(u => new UnitOfWork(u.Resolve<UniverseKinoContext>()))
            .As<IUnitOfWorkEntities>();
            // .InstancePerDependency();


        }

    }
}