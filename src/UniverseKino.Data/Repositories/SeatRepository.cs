using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        public SeatRepository(UniverseKinoContext dbContext)
            : base(dbContext) { }
    }
}
