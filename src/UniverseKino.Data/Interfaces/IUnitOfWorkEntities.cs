using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Interfaces
{
    public interface IUnitOfWorkEntities : IDisposable
    {
        IGenericRepository<Movie> Movies { get; }
        IGenericRepository<CinemaHall> CinemaHalls { get; }
        IGenericRepository<Session> Sessions { get; }
        IGenericRepository<Reservation> Reservations { get; }

        void Save();
    }
}
