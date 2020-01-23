using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IViewInfoService
    {
        SessionDTO GetSession(int id);
        List<SessionDTO> GetSessions();
        MovieDTO GetMovie(int id);
        List<MovieDTO> GetMovies();
    }
}
