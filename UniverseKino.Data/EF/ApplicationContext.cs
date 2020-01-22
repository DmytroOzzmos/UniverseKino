using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.EF
{
    public class IdentityContext : IdentityDbContext<AppIdentityUser>
    {
        public IdentityContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}