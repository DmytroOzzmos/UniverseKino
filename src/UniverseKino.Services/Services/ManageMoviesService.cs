using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.Services.Services
{
    public class ManageMoviesService : IManageMoviesService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public ManageMoviesService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(MovieDTO newMovie)
        {
            var movie = _mapper.Map<Movie>(newMovie);

            if (!IsExistMovie(movie))
            {
                throw new Exception("Movie already exists");
            }

            await _movieRepository.AddAsync(movie);
        }

        public async Task RemoveAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie != null)
                await _movieRepository.RemoveAsync(id);
        }

        private bool IsExistMovie(Movie movie)
        {
            var checkMovie = _movieRepository.FindByPredicate(x => x.Name == movie.Name
                                                && x.Genre == movie.Genre
                                                && x.Duration == movie.Duration).FirstOrDefault();

            return checkMovie == null;
        }
    }
}
