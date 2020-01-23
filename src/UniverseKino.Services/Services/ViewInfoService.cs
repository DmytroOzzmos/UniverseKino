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

        public MovieDTO GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieDTO> GetMovies()
        {
            var movies = uow.Movies.GetAll();

            //map

            return null;
        }

        public SessionDTO GetSession(int id)
        {
            throw new NotImplementedException();
        }

        public List<SessionDTO> GetSessions()
        {
            var sessions = uow.Sessions.GetAll().OrderBy(x => x.Date);

            //map

            return null;
        }
    }
}
