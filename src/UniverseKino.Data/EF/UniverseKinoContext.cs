using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using System.Linq;

namespace UniverseKino.Data.EF
{
    public class UniverseKinoContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        public DbSet<Reservation> Reservations { get; set; }

        public UniverseKinoContext(DbContextOptions<UniverseKinoContext> options)
                    : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaHall>().HasData(
                    new CinemaHall[]
                    {
                        new CinemaHall { Number = 1, Id = 1 },
                        new CinemaHall { Number = 2, Id = 2 },
                        new CinemaHall { Number = 3, Id = 3 },
                        new CinemaHall { Number = 4, Id = 4 },
                    });

            modelBuilder.Entity<Seat>()
                .HasData(GetSeats(10, 7, 100, 1));

            modelBuilder.Entity<Seat>()
                .HasData(GetSeats(10, 5, 100, 2));

            modelBuilder.Entity<Seat>()
                .HasData(GetSeats(10, 10, 150, 3));

            modelBuilder.Entity<Seat>()
                .HasData(GetSeats(12, 9, 200, 4));

            modelBuilder.Entity<Movie>().HasData(
                new Movie[]
                {
                    new Movie {Id = 1, Name = "Avengers", Genre = "Action, superhero, adventure, science fiction, fantasy", Duration = 182  },
                    new Movie {Id = 2, Name = "Knives", Genre = "Crime, drama, mysticism", Duration = 131  },
                    new Movie {Id = 3, Name = "Bad boys", Genre = "Action, comedy, crime", Duration = 124 },
                });

            modelBuilder.Entity<Session>().HasData(
                new Session[]
                 {
                        new Session {Id = 1, Date = GetDate(1, 9), MovieId = 1, CinemaHallId = 1 },
                        new Session {Id = 2, Date = GetDate(3, 9), MovieId = 1, CinemaHallId = 3 },
                        new Session {Id = 3, Date = GetDate(5, 9), MovieId = 1, CinemaHallId = 3 },
                        new Session {Id = 4, Date = GetDate(1, 12), MovieId = 2, CinemaHallId = 1 },
                });

        }
        private static DateTime GetDate(int day = 0, int hour = 8)
        {
            var dateString = (new DateTime()).AddDays(day).ToShortDateString();
            var date = DateTime.Parse(dateString);
            date.AddHours(hour);
            return date;
        }

        private int seatId = 0;

        private IEnumerable<Seat> GetSeats(int countPlace, int numberRow, decimal cost, int cinemaId)
        {
            var list = new List<Seat>();

            for (int i = 1; i <= countPlace; i++)
            {
                for (int j = 1; i <= numberRow; i++)
                {
                    seatId++;
                    list.Add(new Seat { Id = seatId, Cost = cost, IdCinemaHall = 1, Number = j, Row = i });
                }
            }

            return list;
        }
    }
}
