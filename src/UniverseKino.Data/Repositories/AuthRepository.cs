using System.Collections.Generic;
using System.Net.Mime;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using System.Linq;
using System.Threading.Tasks;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class AuthRepository : GenericRepository<ApplicationUser>, IAuthRepository
    {
        public AuthRepository(UniverseKinoContext context)
            :base(context) { }

        

        // public List<ApplicationUser> Users() => _appContext.ApplicationUsers.ToList();
        //public List<ApplicationUser> Users
        //{
        //    get
        //    {
        //        return _appContext.ApplicationUsers.ToList();
        //    }
        //}

        //public async Task<ApplicationUser> AddAsync(ApplicationUser user)
        //{

        //    var savedUser = await _appContext.ApplicationUsers.AddAsync(user);
        //    await _appContext.SaveChangesAsync();

        //    return _appContext.ApplicationUsers.Where(u => u.Email == user.Email).FirstOrDefault();
        //}

        //private UniverseKinoContext _appContext;
        //public AuthRepository(UniverseKinoContext dbContext)
        //{
        //    _appContext = dbContext;
        //}

        //public void SaveChanges()
        //{
        //    _appContext.SaveChanges();
        //}
        //public async Task SaveChangesAsync()
        //{
        //    await _appContext.SaveChangesAsync();
        //}

    }
}