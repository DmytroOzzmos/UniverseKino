using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Services;
using UniverseKino.Services.Interfaces;
using UniverseKino.WEB.Models;
using UniverseKino.Services;

namespace UniverseKino.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private IInfoMoviesService _moviesServ;
        private IMapper _mapper;
        private readonly ISessionsInfoService _sessionsInfoService;

        public InfoController(IInfoMoviesService moviesServ, ISessionsInfoService sessionsInfoService, IMapper mapper)
        {
            _moviesServ = moviesServ;
            _sessionsInfoService = sessionsInfoService;
            _mapper = mapper;
        }


        [HttpGet("sessions")]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessionDTO = _sessionsInfoService.GetAllSessions();

            var sessionModel = _mapper.Map<List<SessionModel>>(sessionDTO);

            return await Task.Run(() => Ok(sessionModel));
        }

        [HttpGet]
        [Route("sessions/{id}")]
        public async Task<IActionResult> GetSession([FromRoute] int id)
        {
            var sessionDTO = _sessionsInfoService.GetSession(id);

            var sessionModel = _mapper.Map<SessionModel>(sessionDTO);

            return await Task.Run(() => Ok(sessionDTO));
        }

        [HttpGet("movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _moviesServ.GetAllMovies();

            return Ok(_mapper.Map<List<MovieDTO>>(movies));
        }

        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovie([FromQuery] int id)
        {
            var movie = await _moviesServ.GetMovieByID(id);

            return Ok(_mapper.Map<MovieDTO>(movie));
        }

        [HttpGet("movies/{id}/sessions")]
        public async Task<IActionResult> GetSessionsMovie([FromQuery] int id)
        {
            var sessions = await _moviesServ.GetMoviesSessions(id);

            return Ok(_mapper.Map<List<SessionDTO>>(sessions));
        }
    }
}
