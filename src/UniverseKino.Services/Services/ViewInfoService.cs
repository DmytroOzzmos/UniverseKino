using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using UniverseKino.Data.Interfaces;

namespace UniverseKino.Services.Services
{
    public class ViewInfoService : IViewInfoService
    {
        private readonly IUnitOfWorkEntities uow;

        public ViewInfoService()
        {

        }

        public List<MovieDTO> GetMovies()
        {
            //var movies = 
            return null;
        }

        public List<SessionDTO> GetSessions()
        {
            throw new NotImplementedException();
        }
    }
}
