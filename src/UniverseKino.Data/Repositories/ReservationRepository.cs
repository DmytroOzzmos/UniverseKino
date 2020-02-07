using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(UniverseKinoContext dbContext)
            : base(dbContext) { }
    }
}
