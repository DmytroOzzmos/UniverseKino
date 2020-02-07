using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Interfaces;

namespace UniverseKino.Services.Services
{
    public class InfoGenericService<TEntityDTO, TEntity> : IInfoGenericService<TEntityDTO, TEntity>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public InfoGenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<TEntityDTO> GetAll()
        {
            var entities = _repository.GetAll().ToList();

            var entitiesDTO = _mapper.Map<List<TEntityDTO>>(entities);

            return entitiesDTO;
        }

        public async Task<TEntityDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var entityDTO = _mapper.Map<TEntityDTO>(entity);

            return entityDTO;
        }
    }
}
