using System;
using System.Threading.Tasks;
using UniverseKino.Data.Identity;

namespace UniverseKino.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IdentityUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        IdentityRoleManager RoleManager { get; }
        Task SaveAsync();
    }

}