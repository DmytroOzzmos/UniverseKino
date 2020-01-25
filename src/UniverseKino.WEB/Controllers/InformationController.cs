using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services.Interfaces;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB
{
    [Route("info")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISessionsInfoService _sessionsInfoService;

        public InformationController(ISessionsInfoService sessionsInfoService, IMapper mapper)
        {
            _sessionsInfoService = sessionsInfoService;
            _mapper = mapper;
        }

        [HttpGet("sessions/all")]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessionDTO = _sessionsInfoService.GetAllSessions();

            var sessionModel = _mapper.Map<SessionModel>(sessionDTO);

            return await Task.Run(() => Ok(sessionModel));
        }

        [HttpGet("sessions/{id}")]
        public async Task<IActionResult> GetSession([FromQuery] int id)
        {
            return await Task.Run(() => Ok());
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetAllMovies()
        {
            return await Task.Run(() => Ok());
        }

        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovie([FromQuery] int id)
        {
            return await Task.Run(() => Ok());
        }

        [HttpGet("movies/{id}/sessions")]
        public async Task<IActionResult> GetSessionsMovie([FromQuery] int id)
        {
            return await Task.Run(() => Ok());
        }
    }
}
