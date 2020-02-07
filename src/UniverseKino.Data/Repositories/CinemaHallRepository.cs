using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class CinemaHallRepository : GenericRepository<CinemaHall>, ICinemaHallRepository
    {
        public CinemaHallRepository(UniverseKinoContext dbContext) 
            : base(dbContext) { }
    }
}
