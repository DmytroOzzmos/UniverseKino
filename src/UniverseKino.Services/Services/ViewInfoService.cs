using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using UniverseKino.Data.Interfaces;
using System.Linq;
using AutoMapper;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services.Services
{
    public class ViewInfoService : IViewInfoService
    {
        private readonly IUnitOfWorkEntities _uow;
        private readonly IMapper _mapper;

        public ViewInfoService(IUnitOfWorkEntities uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public MovieDTO GetMovie(int id)
        {
            var movie = _uow.Sessions.GetByIdAsync(id);

            var movies = _mapper.Map<MovieDTO>(movie);

            return movies;
        }

        public List<MovieDTO> GetMovies()
        {
            var movies = _uow.Movies.GetAllAsync().ToList();

            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            return moviesDTO;
        }

        public SessionDTO GetSession(int id)
        {
            var session = _uow.Sessions.GetByIdAsync(id);

            var sessionDTO = _mapper.Map<SessionDTO>(session);

            return sessionDTO;
        }

        public List<SessionDTO> GetSessions()
        {
            var sessions = _uow.Sessions.GetAllAsync().OrderBy(x => x.Date).ToList();

            var sessionDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionDTO;
        }
    }
}
