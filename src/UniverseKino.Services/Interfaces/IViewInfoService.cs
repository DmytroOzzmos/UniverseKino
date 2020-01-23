using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IViewInfoService
    {
        List<SessionDTO> GetSessions();
        List<MovieDTO> GetMovies();
    }
}
