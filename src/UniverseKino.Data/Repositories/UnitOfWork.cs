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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UniverseKinoContext _dbContext;
        private readonly Dictionary<Type, object> _repositoties = new Dictionary<Type, object>();

        public UnitOfWork(UniverseKinoContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Repositories
        public IAuthRepository AuthRepository => CreateRepository(() => new AuthRepository(_dbContext));

        public ICinemaHallRepository CinemaHallRepository => CreateRepository(() => new CinemaHallRepository(_dbContext));

        public IMovieRepository MovieRepository => CreateRepository(() => new MovieRepository(_dbContext));

        public ISeatRepository SeatRepository => CreateRepository(() => new SeatRepository(_dbContext));

        public ISessionRepository SessionRepository => CreateRepository(() => new SessionRepository(_dbContext));
        #endregion

        private T CreateRepository<T>(Func<T> createRepository) where T : class
        {
            var typeRepository = typeof(T);
            if (_repositoties.ContainsKey(typeRepository))
                return _repositoties[typeRepository] as T;

            var result = createRepository();

            _repositoties.Add(typeRepository, result);
            return result;
        }

        #region Dispose
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
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }
        #endregion

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
