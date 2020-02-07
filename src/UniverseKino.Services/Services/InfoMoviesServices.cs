using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Services
{
    public interface IInfoMoviesService
    {
        MovieDTO GetMovieByID(int id);
        MovieDTO GetMovieByName(string movieName);
        List<SessionDTO> GetMoviesSessions(int id);
        List<MovieDTO> GetAllMovies();


    }
    public class InfoMoviesService : IInfoMoviesService
    {
        private IUnitOfWorkEntities _unit;
        private IMapper _mapper;
        public InfoMoviesService(IUnitOfWorkEntities unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }


        public List<MovieDTO> GetAllMovies()
        {
            var movies = _unit.Movies.GetAllAsync();

            return _mapper.Map<List<MovieDTO>>(movies);
        }

        public MovieDTO GetMovieByID(int id)
        {
            var movie = _unit.Movies.GetByIdAsync(id);

            return _mapper.Map<MovieDTO>(movie);
        }

        public MovieDTO GetMovieByName(string movieName)
        {
            var movie = _unit.Movies.FindAsync(m =>
                             m.Name.ToLower() == movieName.ToLower())
                             .FirstOrDefault();

            if (movie == null)
                throw new Exception();

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        public List<SessionDTO> GetMoviesSessions(int id)
        {
            var movie = _unit.Movies.GetByIdAsync(id);

            var sessions = movie.Sessions.OrderBy(s => s.Date).ToList();

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }
    }
}