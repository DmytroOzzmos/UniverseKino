using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IInfoMoviesService : IInfoGenericService<MovieDTO, Movie>
    {
        Task<MovieDTO> GetMovieByNameAsync(string movieName);
        Task<List<SessionDTO>> GetMoviesSessionsAsync(int id);
    }
}
