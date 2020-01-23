using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Identity;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Data.Repositories
{
    public class UnitOfWork : IUnitOfWorkEntities
    {
        private readonly 

        public UnitOfWork()
        {

        }

        public IGenericRepository<Movie> Movies
        {
            get
            {

            }
        }

        public IGenericRepository<CinemaHall> CinemaHalls => throw new NotImplementedException();

        public IGenericRepository<Session> Sessions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGenericRepository<Reservation> Reservations => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
