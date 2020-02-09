using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using UniverseKino.Services.Exceptions;

namespace UniverseKino.Services.Services
{
    public class InfoMoviesService : InfoGenericService<MovieDTO, Movie>, IInfoMoviesService
    {
        private readonly IMovieRepository _movieRepository;

        public InfoMoviesService(IMovieRepository movieRepository, IMapper mapper)
            : base(movieRepository, mapper)
        {
            _movieRepository = movieRepository;
        }


        public async Task<MovieDTO> GetMovieByNameAsync(string movieName)
        {
            
            var movie = await Task.Run( () =>
                                  _movieRepository.FindByPredicate(m =>
                                   m.Name.ToLower() == movieName.ToLower() ));

            if (movie == null)
                throw new EntityIsNotExistException("Movie is not exist");

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        public async Task<List<SessionDTO>> GetMoviesSessionsAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
                throw new EntityIsNotExistException("Movie is not exist");

            var sessions = movie.Sessions.OrderBy(s => s.Date).ToList();

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }
    }
}