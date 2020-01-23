using Microsoft.EntityFrameworkCore;
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

        public UniverseKinoContext(DbContextOptions options) : base(options) { }
    }
}
