using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.EF;

namespace UniverseKino.Data.Repositories
{
    public class UnitOfWork : IUnitOfWorkEntities, IDisposable
    {
        private readonly UniverseKinoContext dbContext;

        private IGenericRepository<Movie> movies;
        private IGenericRepository<CinemaHall> cinemaHalls;
        private IGenericRepository<Session> sessions;
        private IGenericRepository<Reservation> reservations;

        public UnitOfWork(UniverseKinoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRepository<Movie> Movies
        {
            get
            {
                if (movies == null)
                    movies = new GenericRepository<Movie>(dbContext);

                return movies;
            }
        }

        public IGenericRepository<CinemaHall> CinemaHalls
        {
            get
            {
                if (cinemaHalls == null)
                    cinemaHalls = new GenericRepository<CinemaHall>(dbContext);

                return cinemaHalls;
            }
        }

        public IGenericRepository<Session> Sessions
        {
            get
            {
                if (sessions == null)
                    sessions = new GenericRepository<Session>(dbContext);

                return sessions;
            }
        }

        public IGenericRepository<Reservation> Reservations
        {
            get
            {
                if (reservations == null)
                    reservations = new GenericRepository<Reservation>(dbContext);

                return reservations;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
