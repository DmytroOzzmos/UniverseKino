using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;

namespace UniverseKino.Services.Services
{
    public class ManageMoviesService : IManageMoviesService
    {
        private readonly IUnitOfWorkEntities _uow;
        private readonly IMapper _mapper;
        private readonly ICheckService _check;

        public ManageMoviesService(IUnitOfWorkEntities uow, IMapper mapper, ICheckService check)
        {
            _uow = uow;
            _mapper = mapper;
            _check = check;
        }

        public void Add(MovieDTO newMovie)
        {
            var movie = _mapper.Map<Movie>(newMovie);

            if (!_check.ValidationMovie(movie))
            {
                throw new Exception("Invalid data");
            }

            _uow.Movies.Add(movie);

            if (!_check.IsExistMovie(movie))
            {
                throw new Exception("Failed to add movie");
            }
        }

        public void Remove(int id)
        {
            var movie = _uow.Movies.GetByIdAsync(id);

            if (movie == null)
            {
                throw new Exception("IsNotExist");
            }

            _uow.Movies.RemoveAsync(id);
        }
    }
}
