using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(int id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate);

        Task<TEntity> GetById(int id);
    }
}
