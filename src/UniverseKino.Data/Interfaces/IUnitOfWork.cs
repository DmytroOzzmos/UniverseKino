using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository { get; }
        ICinemaHallRepository CinemaHallRepository { get; }
        IMovieRepository MovieRepository { get; }
        ISeatRepository SeatRepository { get; }
        ISessionRepository SessionRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
