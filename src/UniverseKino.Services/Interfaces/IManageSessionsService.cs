using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IManageSessionsService
    {
        Task AddAsync(CreateSassionDTO newSession);
        Task RemoveAsync(int id);
    }
}
