using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Identity
{
    public class IdentityRoleManager : RoleManager<AppIdentityRole>
    {
        public IdentityRoleManager(RoleStore<AppIdentityRole> store)
                    : base(store)
        { }
    }
}