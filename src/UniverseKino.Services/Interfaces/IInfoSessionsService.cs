using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services.Interfaces
{
    public interface IInfoSessionsService
    {
        Task<SessionDTO> GetSession(int id);
        Task<List<SessionDTO>> GetAllSessions();
        Task<List<SessionDTO>> GetSessionsByMovie(int idMovie);
    }
}
