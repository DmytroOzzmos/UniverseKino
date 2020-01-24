using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UniverseKino.WEB.Controllers
{
    [Route("info")]
    [ApiController]
    public class InformationController : ControllerBase
    {
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
