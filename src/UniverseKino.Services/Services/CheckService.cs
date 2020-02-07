using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Interfaces;
using System.Linq;

namespace UniverseKino.Services.Services
{
    public class CheckService : ICheckService
    {
        private readonly IUnitOfWorkEntities _uow;

        public CheckService(IUnitOfWorkEntities uow)
        {
            _uow = uow;
        }

        public bool ValidationMovie(Movie movie)
        {
            return movie != null && movie.Duration <= 0;
        }

        public bool IsExistMovie(Movie movie)
        {
            var checkMovie = _uow.Movies.FindAsync(x => x.Name == movie.Name
                                                && x.Genre == movie.Genre
                                                && x.Duration == movie.Duration).FirstOrDefault();

            return checkMovie != null;
        }



        public void ValidationSession(Session session)
        {
            if (session.Date < DateTime.Now)
            {
                throw new Exception();
            }
        }
    }
}
