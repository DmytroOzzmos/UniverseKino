using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace UniverseKino.Data.Repositories
{
    public class UnitOfWork : IUnitOfWorkEntities, IDisposable
    {
        private readonly UniverseKinoContext dbContext;

        private IGenericRepository<Movie> movies;
        private IGenericRepository<CinemaHall> cinemaHalls;
        private IGenericRepository<Session> sessions;
        private IGenericRepository<Reservation> reservations;
        private IGenericRepository<Seat> seats;

        public UnitOfWork(UniverseKinoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IGenericRepository<T> GetRepository<T>()  where T : BaseEntity
        {
            return GetRepository<T>();
        }

        public IGenericRepository<Movie> Movies
        {
            get
            {
                if (movies == null)
                    movies = GetRepository<Movie>();

                return movies;
            }
        }

        public IGenericRepository<CinemaHall> CinemaHalls
        {
            get
            {
                if (cinemaHalls == null)
                    cinemaHalls = GetRepository<CinemaHall>();

                return cinemaHalls;
            }
        }

        public IGenericRepository<Seat> Seats
        {
            get
            {
                if (seats == null)
                    seats = GetRepository<Seat>();

                return seats;
            }
        }

        public IGenericRepository<Session> Sessions
        {
            get
            {
                if (sessions == null)
                    sessions = GetRepository<Session>();

                return sessions;
            }
        }

        public IGenericRepository<Reservation> Reservations
        {
            get
            {
                if (reservations == null)
                    reservations = GetRepository<Reservation>();

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
