using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.EF
{
    public class IdentityContext : IdentityDbContext<AppIdentityUser>
    {
        public IdentityContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}