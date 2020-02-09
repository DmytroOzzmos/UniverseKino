using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IManageMoviesService
    {
        Task AddAsync(MovieDTO session);
        Task RemoveAsync(int id);
    }
}
