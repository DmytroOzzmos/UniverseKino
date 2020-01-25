using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.EF
{
    public class UniverseKinoContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public UniverseKinoContext(DbContextOptions<UniverseKinoContext> options)
                    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaHall>().HasData(

                    new CinemaHall[]
                    {
                        new CinemaHall { Number = 1, Id = 1 },
                        new CinemaHall { Number = 2, Id = 2 },
                        new CinemaHall { Number = 3, Id = 3 },
                        new CinemaHall { Number = 4, Id = 4 },
                    }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie[]
                {
                    new Movie {Id = 1, Name = "Movie1", Genre = "FantastikaBlya", Duration = 100  },
                    new Movie {Id = 2, Name = "Second movie ska", Genre = "TravelYopta", Duration = 187  },
                    new Movie {Id = 3, Name = "LastNah", Genre = "Ujastik", Duration = 250 },
                }
            );


            modelBuilder.Entity<Session>().HasData(
                new Session[]
                 {
                        new Session {Id = 1, Date = GetDate(1, 9), IdMovie = 1, IdCinemaHall = 1 },
                        new Session {Id = 2, Date = GetDate(3, 9), IdMovie = 1, IdCinemaHall = 3 },
                        new Session {Id = 3, Date = GetDate(5, 9), IdMovie = 1, IdCinemaHall = 3 },
                        new Session {Id = 4, Date = GetDate(1, 12), IdMovie = 2, IdCinemaHall = 1 },
                }
            );

        }
        private static DateTime GetDate(int day = 0, int hour = 8)
        {
            var dateString = (new DateTime()).AddDays(day).ToShortDateString();
            var date = DateTime.Parse(dateString);
            date.AddHours(hour);
            return date;

        }

    }
}
