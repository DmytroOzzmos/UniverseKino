using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using System.Linq;

namespace UniverseKino.Services.Services
{
    public class ManageSessionsService : IManageSessionsService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly IMapper _mapper;

        public ManageSessionsService(ISessionRepository sessionRepository, IMovieRepository movieRepository, ICinemaHallRepository cinemaHallRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaHallRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateSessionDTO newSession)
        {
            var session = _mapper.Map<Session>(newSession);

            await SessionValidAsync(session);

            await _sessionRepository.AddAsync(session);
        }

        public async Task RemoveAsync(int id)
        {
            var session = await _sessionRepository.GetByIdAsync(id);

            if (session != null)
                await _sessionRepository.RemoveAsync(id);
        }


        private async Task SessionValidAsync(Session session)
        {
            await IsExistHall(session.CinemaHallId);
            await IsExistMovie(session.MovieId);
            await IsLeisureTime(session);
        }

        private async Task IsExistMovie(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);

            if (movie == null)
            {
                throw new Exception("this movie is not exist");
            }
        }

        private async Task IsExistHall(int hallId)
        {
            var hall = await _cinemaHallRepository.GetByIdAsync(hallId);

            if (hall == null)
            {
                throw new Exception("this hall is not exist");
            }
        }

        private async Task IsLeisureTime(Session session)
        {
            await IsLeisureTimePre(session);
            await IsLeisureTimeNext(session);
        }

        private async Task IsLeisureTimePre(Session session)
        {
            var preSession = await Task.Run( () => _sessionRepository
                .FindByPredicate(x => 
                    x.Date <= session.Date)
                .OrderBy(x => x.Date)
                .FirstOrDefault() );

            if (preSession != null && preSession.Date.AddMinutes(preSession.Movie.Duration + 10) <= session.Date)
            {
                throw new Exception("Scheduled time taken");
            }
        }

        private async Task IsLeisureTimeNext(Session session)
        {
            var nextSession = await Task.Run( () => _sessionRepository
                .FindByPredicate(x =>
                    x.Date >= session.Date)
                .OrderBy(x => x.Date)
                .FirstOrDefault() );

            var movie = await _movieRepository.GetByIdAsync(session.MovieId);

            if (nextSession != null && session.Date.AddMinutes(movie.Duration + 10) <= nextSession.Date)
            {
                throw new Exception("Scheduled time taken");
            }
        }
    }
}
