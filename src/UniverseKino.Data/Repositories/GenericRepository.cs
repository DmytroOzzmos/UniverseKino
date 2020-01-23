using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniverseKino.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly UniverseKinoContext dbContext;

        private DbSet<TEntity> Entities
        {
            get
            {
                return dbContext.Set<TEntity>();
            }
        }

        public GenericRepository(UniverseKinoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            var listResult = Entities.Where(predicate);

            return listResult;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(int id)
        {
            var entity = Entities.Where(x => x.Id == id).FirstOrDefault();

            return entity;
        }

        public void Remove(int id)
        {
            var removeEntity = GetById(id);

            Entities.Remove(removeEntity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
