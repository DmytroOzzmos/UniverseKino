using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using System.Linq;

namespace UniverseKino.Services.Services
{
    public class SessionsInfoService : ISessionsInfoService
    {
        private readonly IUnitOfWorkEntities _uow;
        private readonly IMapper _mapper;

        public SessionsInfoService(IUnitOfWorkEntities uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<SessionDTO> GetAllSessions()
        {
            using (_uow)
            {
                var sessions = _uow.Sessions.GetAll().OrderBy(x => x.Date).ToList();

                var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

                return sessionsDTO;
            }
        }

        public SessionDTO GetSession(int id)
        {
            var session = _uow.Sessions.GetById(id);

            if (session == null)
                throw new Exception("DataNotExist");

            var sessionDTO = _mapper.Map<SessionDTO>(session);

            return sessionDTO;
        }

        public List<SessionDTO> GetSessionsByMovie(int idMovie)
        {
            var movie = _uow.Movies.GetById(idMovie);

            if (movie == null)
                throw new Exception("Movie is not exist");

            var sessions = _uow.Sessions.Find(s => s.IdMovie == idMovie).OrderBy(s => s.Date).ToList();

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }
    }
}
