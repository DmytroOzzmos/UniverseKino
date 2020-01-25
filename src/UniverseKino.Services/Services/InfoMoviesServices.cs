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
        Task<MovieDTO> GetMovieByID(int id);
        Task<MovieDTO> GetMovieByName(string movieName);
        //Task<List<SessionDTO>> GetMoviesSessions(int id);
        Task<List<MovieDTO>> GetAllMovies();
        //List<MovieDTO> GetAllMovies();


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


        //public List<MovieDTO> GetAllMovies()
        //{
        //    var a = rep.GetAll();
        //    // return await Task.Run(() =>_moviesRepo.GetAll());
        //    return _mapper.Map<List<MovieDTO>>(rep.GetAll());
        //}
        public async Task<List<MovieDTO>> GetAllMovies()
        {
            // return await Task.Run(() =>_moviesRepo.GetAll());
            var movies1 = await Task.Run(() =>
            {
                var movies = new List<Movie>();

                using (_unit)
                {
                    movies = _unit.Movies.GetAll().ToList();
                }

                return movies;
            });


            return _mapper.Map<List<MovieDTO>>(movies1);
        }

        public async Task<MovieDTO> GetMovieByID(int id)
        {
            var movie = await Task.Run(() =>
                {
                    // var movie = new List<Movie>();
                    using (_unit)
                    {
                        return _unit.Movies.GetById(id);
                    }
                });

            //    _moviesRepo.GetById(id));
            if (movie == null)
            {
                throw new Exception();
            }

            //return movie;
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task<MovieDTO> GetMovieByName(string movieName)
        {
            var movie = await Task.Run(() =>
                        _unit.Movies.Find((m) =>
                         m.Name.ToLower() == movieName.ToLower())
                        .FirstOrDefault()
                        );

            if (movie == null)
            {
                throw new Exception();
            }

            return _mapper.Map<MovieDTO>(movie);
        }

        //public async Task<List<SessionDTO>> GetMoviesSessions(int id)
        //{
        //    var movie = await GetMovieByID(id);

        //    return movie.Sessions.ToList();
        //    // var movieSessions = _mapper.Map<ICollection<Ses
        //    // movie.Sessions.ToList()

        //    // throw new System.NotImplementedException();
        //}
    }
}