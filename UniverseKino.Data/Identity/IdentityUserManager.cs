using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(UserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}