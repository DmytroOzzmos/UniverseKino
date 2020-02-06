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
                    : base(options)
        {
            //Database.EnsureCreated();

        }

        //public UniverseKinoContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UniverseKinoDEV;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var cinemaHall1 = new CinemaHall { Number = 1, Id = 1 };
            //var cinemaHall2 = new CinemaHall { Number = 2, Id = 2 };
            //var cinemaHall3 = new CinemaHall { Number = 3, Id = 3 };
            //var cinemaHall4 = new CinemaHall { Number = 4, Id = 4 };


            //modelBuilder.Entity<CinemaHall>().HasData(

            //        new CinemaHall[]
            //        {
            //            cinemaHall1,
            //            cinemaHall2,
            //            cinemaHall3,
            //            cinemaHall4,
            //        }
            //);

            //var movie1 = new Movie { Id = 1, Name = "Movie1", Genre = "FantastikaBlya", Duration = 100 };
            //var movie2 = new Movie { Id = 2, Name = "Second movie ska", Genre = "TravelYopta", Duration = 187 };
            //var movie3 = new Movie { Id = 3, Name = "LastNah", Genre = "Ujastik", Duration = 250 };

            //modelBuilder.Entity<Movie>().HasData(
            //    new Movie[]
            //    {
            //        movie1,
            //        movie2,
            //        movie3
            //    }
            //);


            //modelBuilder.Entity<Session>().HasData(
            //    new Session[]
            //     {
            //            new Session {Id = 1, Date = GetDate(1, 9), Movie = movie1, CinemaHall = cinemaHall1 },
            //            new Session {Id = 2, Date = GetDate(3, 9), Movie = movie1, CinemaHall = cinemaHall3 },
            //            new Session {Id = 3, Date = GetDate(5, 9), Movie = movie1, CinemaHall = cinemaHall3 },
            //            new Session {Id = 4, Date = GetDate(1, 12), Movie = movie2, CinemaHall = cinemaHall1 },
            //    }
            //);

        }
        private static DateTime GetDate(int day = 0, int hour = 8)
        {
            var dateString = (new DateTime()).AddDays(day).ToShortDateString();
            var date = DateTime.Parse(dateString);
            date.AddHours(hour);
            return date;
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var init = new InitDb(modelBuilder);
        //    init.InitCinemaHall();
        //}
    }
}
