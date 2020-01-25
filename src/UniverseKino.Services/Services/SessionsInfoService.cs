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
        private readonly ICheckService _check;

        public SessionsInfoService(IUnitOfWorkEntities uow, IMapper mapper, ICheckService check)
        {
            _uow = uow;
            _mapper = mapper;
            _check = check;
        }

        public List<SessionDTO> GetAllSessions()
        {
            var sessions = _uow.Sessions.GetAll().OrderBy(x => x.Date).ToList();

            var sessionsDTO = _mapper.Map<List<SessionDTO>>(sessions);

            return sessionsDTO;
        }

        public SessionDTO GetSession(int id)
        {
            if (!_check.IsExistSession(id))
                throw new Exception("DataNotExist");


        }
    }
}
