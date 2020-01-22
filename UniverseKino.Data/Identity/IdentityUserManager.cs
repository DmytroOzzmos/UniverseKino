using Microsoft.AspNet.Identity;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Identity
{
    public class IdentityUserManager : UserManager<AppIdentityUser>
    {
        public IdentityUserManager(IUserStore<AppIdentityUser> store)
                : base(store)
        {
        }
    }
}