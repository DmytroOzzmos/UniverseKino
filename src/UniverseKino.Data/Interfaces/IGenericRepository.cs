using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;

namespace UniverseKino.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task RemoveAsync(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindByPredicate(Func<TEntity, bool> predicate);

        Task<TEntity> GetByIdAsync(int id);
    }
}
