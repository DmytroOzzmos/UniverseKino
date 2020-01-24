using System.Collections.Generic;
using System.Net.Mime;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.Data.Repositories
{
    public class AuthRepository
    {
        public List<ApplicationUser> Users { get; set; }

        private ApplicationContext _appContext;
        public AuthRepository(ApplicationContext dbContext)
        {
            _appContext = dbContext;
            Users = dbContext.ApplicationUsers.ToList();
        }

        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _appContext.SaveChangesAsync();
        }

    }
}