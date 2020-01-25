using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.Services.Services
{
    public class InfoSessionsService : IInfoSessionsService
    {
        private readonly IUnitOfWorkEntities _uow;
        private readonly IMapper _mapper;

        public InfoSessionsService(IUnitOfWorkEntities uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<SessionDTO>> GetAllSessions()
        {
            var sessions = await Task.Run(() =>
            {
                return _uow.Sessions.GetAll()
                .OrderBy(x => x.Date)
                .ToList();
            });

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }

        public async Task<SessionDTO> GetSession(int id)
        {
            var session = await Task.Run(() =>
                    _uow.Sessions.GetById(id));

            if (session == null)
                throw new Exception("DataNotExist");

            var sessionDTO = _mapper.Map<SessionDTO>(session);

            return sessionDTO;
        }

        public async Task<List<SessionDTO>> GetSessionsByMovie(int idMovie)
        {
            var movie = await Task.Run(() => 
                    _uow.Movies.GetById(idMovie));

            if (movie == null)
                throw new Exception("Movie is not exist");

            var sessions = _uow.Sessions.Find(s => s.IdMovie == idMovie).OrderBy(s => s.Date).ToList();

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }
    }
}
