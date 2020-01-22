using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using UniverseKino.Data.EF;
using UniverseKino.Data.Identity;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private IdentityContext db;

        private IdentityUserManager userManager;
        private IdentityRoleManager roleManager;
        private IClientManager clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new IdentityContext(connectionString);
            userManager = new IdentityUserManager(new UserStore<AppIdentityUser>(db));
            roleManager = new IdentityRoleManager(new RoleStore<IdentityRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public IdentityRoleManager RoleManager
        {
            get { return roleManager; }
        }

        IdentityUserManager IUnitOfWork.UserManager => throw new System.NotImplementedException();

        IdentityRoleManager IUnitOfWork.RoleManager => throw new System.NotImplementedException();

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}