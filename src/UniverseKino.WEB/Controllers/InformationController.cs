using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Services;

namespace UniverseKino.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private IInfoMoviesService _moviesServ;
        private IMapper _mapper;

        public InfoController(IInfoMoviesService moviesServ, IMapper mapper)
        {
            _moviesServ = moviesServ;
            _mapper = mapper;
        }

        [HttpGet("schedule")]
        public async Task<IActionResult> GetAllSessions()
        {
            return await Task.Run(() => Ok("Go to the nahuy"));
        }

        [HttpGet("sessions/{id}")]
        public async Task<IActionResult> GetSession([FromQuery] int id)
        {
            return await Task.Run(() => Ok());
        }

        [HttpGet]
        [Route("movies")]
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
