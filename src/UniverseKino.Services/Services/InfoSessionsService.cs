using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using System.Linq;
using UniverseKino.Data.Entities;
using System.Threading.Tasks;

namespace UniverseKino.Services.Services
{
    public class InfoSessionsService : InfoGenericService<SessionDTO, Session>, IInfoSessionsService
    {
        private readonly ISessionRepository _sessionRepository;
        //private readonly IMapper _mapper;

        public InfoSessionsService(ISessionRepository sessionRepository, IMapper mapper)
            : base(sessionRepository, mapper) 
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<SessionDTO>> GetSessionsByMovie(int idMovie)
        {
            var sessions = await Task.Run( () =>
                                        _sessionRepository.FindByPredicate(s => s.MovieId == idMovie)
                                             .OrderBy(s => s.Date)
                                             .ToList());

            if (sessions == null)
                throw new Exception("Session is not exist");


            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }
    }
}
