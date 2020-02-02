using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.EF
{
    public class ApplicationContext : DbContext
    {
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}