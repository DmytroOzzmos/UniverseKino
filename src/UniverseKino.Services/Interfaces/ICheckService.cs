using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services.Interfaces
{
    public interface ICheckService
    {
        bool ValidationMovie(Movie movie);
        bool IsExistMovie(int id);
        bool IsExistMovie(Movie movie);

        void ValidationSession(Session session);
    }
}
