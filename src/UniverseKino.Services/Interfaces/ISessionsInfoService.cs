using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface ISessionsInfoService
    {
        SessionDTO GetSession(int id);
        List<SessionDTO> GetAllSessions();
        List<SessionDTO> GetSessionsByMovie(int idMovie);
    }
}
