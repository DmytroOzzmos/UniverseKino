using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseKino.WEB
{
    [Route("admin")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpPost("sessions")]
        public IActionResult CreateSessinons([FromBody] CreateSessionRequestModel newSession)
        {
            return Ok();
        }

        [HttpDelete("sessions/{id}")]
        public IActionResult DeleteSessinons([FromRoute]int id)
        {
            return Ok();
        }


        [HttpPost("movies")]
        public IActionResult CreateMovies([FromBody] CreateMovieRequestModel newMovie)
        {
            return Ok();
        }


        [HttpDelete("movies/{id}")]
        public IActionResult DeleteMovies([FromRoute] int id)
        {
            return Ok();
        }
    }
}
