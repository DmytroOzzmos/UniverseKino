

using System;
using System.Threading.Tasks;
using UniverseKino.Data.Identity;

namespace UniverseKino.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }

}