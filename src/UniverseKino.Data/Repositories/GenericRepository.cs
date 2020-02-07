using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UniverseKino.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly UniverseKinoContext _dbContext;

        public GenericRepository(UniverseKinoContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<TEntity> Entities
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }


        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => Entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => Entities.Where(predicate));
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }
    }
}
