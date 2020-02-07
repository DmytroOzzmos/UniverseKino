using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UniverseKino.Services.Interfaces
{
    public interface IInfoGenericService<TEntityDTO, TEntity> 
        where TEntityDTO : class
        where TEntity : class
    {
        Task<TEntityDTO> GetByIdAsync(int id);
        List<TEntityDTO> GetAll();
    }
}
