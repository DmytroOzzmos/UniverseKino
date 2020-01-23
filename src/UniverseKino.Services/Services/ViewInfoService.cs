using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using UniverseKino.Data.Interfaces;
using System.Linq;

namespace UniverseKino.Services.Services
{
    public class ViewInfoService : IViewInfoService
    {
        private readonly IUnitOfWorkEntities uow;

        public ViewInfoService(IUnitOfWorkEntities uow)
        {
            this.uow = uow;
        }

        public List<MovieDTO> GetMovies()
        {
            var movies = uow.Movies.GetAll();



            return null;
        }

        public List<SessionDTO> GetSessions()
        {
            throw new NotImplementedException();
        }
    }
}
