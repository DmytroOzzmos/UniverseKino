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
using UniverseKino.WEB.Filters;

namespace UniverseKino.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(DefaultExceptionFilter))]
    public class InfoController : ControllerBase
    {
        private readonly IInfoMoviesService _moviesInfoService;
        private readonly IInfoSessionsService _sessionsInfoService;
        private readonly IMapper _mapper;

        public InfoController(IInfoMoviesService moviesService, IInfoSessionsService sessionsInfoService, IMapper mapper)
        {
            _moviesInfoService = moviesService;
            _sessionsInfoService = sessionsInfoService;
            _mapper = mapper;
        }


        [HttpGet("sessions")]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessionDTO = await Task.Run( () => _sessionsInfoService.GetAll());

            return Ok(sessionDTO);
        }

        [HttpGet]
        [Route("sessions/{id}")]
        public async Task<IActionResult> GetSession([FromRoute] int id)
        {
            var sessionDTO = await _sessionsInfoService.GetByIdAsync(id);

            return Ok(sessionDTO);
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await Task.Run( () => _moviesInfoService.GetAll());

            return Ok(movies);
        }

        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            var movie = await _moviesInfoService.GetByIdAsync(id);

            return Ok(movie);
        }

        [HttpGet("movies/{id}/sessions")]
        public async Task<IActionResult> GetSessionsMovie([FromRoute] int id)
        {
            var sessions = await _moviesInfoService.GetMoviesSessionsAsync(id);

            return Ok(sessions);
        }
    }
}
