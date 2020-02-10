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
    public class TestsManageMoviesService
    {
        private readonly MovieDTO movieDTO = new MovieDTO
        {
            Name = "qwe",
            Genre = "asd",
            Duration = 123
        };

        private readonly Movie movie = new Movie
        {
            Id = 1,
            Name = "qwe",
            Genre = "asd",
            Duration = 123
        };

        [Fact]
        public async void AddMovieAsync_Addition_Void()
        {
            var repMock = new Mock<IMovieRepository>();
            var mapperMock = new Mock<IMapper>();

            var manageMovie = new ManageMoviesService(repMock.Object, mapperMock.Object);

            await manageMovie.AddAsync(movieDTO);

            repMock.Verify(x => x.AddAsync(It.IsAny<Movie>()));
        }

        [Fact]
        public async void AddMovieAsync_Addition_EntityAlreadyExistsException()
        {
            var repMock = new Mock<IMovieRepository>();
            var mapperMock = new Mock<IMapper>();

            var manageMovie = new ManageMoviesService(repMock.Object, mapperMock.Object);

            repMock
                .Setup(x => x.FindByPredicate(It.IsAny<Func<Movie, bool>>()))
                .Returns(new List<Movie> { movie });

            await Assert.ThrowsAsync<EntityAlreadyExistsException>( () => manageMovie.AddAsync(movieDTO));
            
        }

        [Fact]
        public async void RemoveMovieAsync_Remove_Void()
        {
            var repMock = new Mock<IMovieRepository>();
            var mapperMock = new Mock<IMapper>();

            var manageMovie = new ManageMoviesService(repMock.Object, mapperMock.Object);

            repMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.Run(() => movie));

            await manageMovie.RemoveAsync(movie.Id);

            repMock.Verify(x => x.RemoveAsync(It.IsAny<int>()));
        }
    }
}
