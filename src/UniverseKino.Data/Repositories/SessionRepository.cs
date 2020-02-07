using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(UniverseKinoContext dbContext)
            : base(dbContext) { }
    }
}
