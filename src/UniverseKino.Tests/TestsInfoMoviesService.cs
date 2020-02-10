using System;
using Xunit;
using Moq;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services;
using AutoMapper;
using System.Collections.Generic;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Services;
using UniverseKino.Services.Dto;
using System.Threading.Tasks;
using UniverseKino.Services.Exceptions;

namespace UniverseKino.Tests
{
    public class TestsInfoMoviesService
    {
        private readonly Movie movie = new Movie
        {
            Id = 1,
            Name = "qwe",
            Genre = "asd",
            Duration = 123
        };

        [Fact]
        public void GetAllMovies_Mapping_AllListMoviesDTO()
        {
            var listMovies = new List<Movie> { movie };

            var mockRep = new Mock<IMovieRepository>();
            var mapper = new MapperConfiguration(mc => mc.AddProfile(new ServicesMappingProfile())).CreateMapper();

            var movieService = new InfoMoviesService(mockRep.Object, mapper);

            mockRep
                .Setup(x => x.GetAll())
                .Returns(() => listMovies);

            var resultList = movieService.GetAll();

            Assert.True(listMovies[0].Name == resultList[0].Name &&
                        listMovies[0].Genre == resultList[0].Genre &&
                        listMovies[0].Duration == resultList[0].Duration);
        }

        [Fact]
        public async void GetByIdAsync_Mapping_MovieDTO()
        {
            var repMock = new Mock<IMovieRepository>();
            var mapper = new MapperConfiguration(mc => mc.AddProfile(new ServicesMappingProfile())).CreateMapper();

            var movieService = new InfoMoviesService(repMock.Object, mapper);

            repMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.Run(() => movie));

            var resultMovie = await movieService.GetByIdAsync(movie.Id);

            Assert.True(movie.Name == resultMovie.Name &&
                        movie.Genre == resultMovie.Genre &&
                        movie.Duration == resultMovie.Duration);
        }

        [Fact]
        public async void GetMovieByNameAsync_Mapping_MovieDTO()
        {
            var listMovies = new List<Movie> { movie };

            var repMock = new Mock<IMovieRepository>();
            var mapper = new MapperConfiguration(mc => mc.AddProfile(new ServicesMappingProfile())).CreateMapper();

            var movieService = new InfoMoviesService(repMock.Object, mapper);

            repMock
                .Setup(x => x.FindByPredicate(It.IsAny<Func<Movie, bool>>()))
                .Returns(listMovies);

            var resultMovie = await movieService.GetMovieByNameAsync(movie.Name);

            Assert.True(movie.Name == resultMovie.Name &&
                        movie.Genre == resultMovie.Genre &&
                        movie.Duration == resultMovie.Duration);
        }

        [Fact]
        []
        public void GetMovieByNameAsync_NotExist_EntityIsNotExistException()
        {
            var repMock = new Mock<IMovieRepository>();
            var mapper = new MapperConfiguration(mc => mc.AddProfile(new ServicesMappingProfile())).CreateMapper();

            var movieService = new InfoMoviesService(repMock.Object, mapper);

            repMock
                .Setup(x => x.FindByPredicate(It.IsAny<Func<Movie, bool>>()))
                .Returns(new List<Movie> { movie });

            Action actual = async () => await movieService.GetMovieByNameAsync(movie.Name);

            Assert.Throws<EntityIsNotExistException>(actual);
        }
    }
}
