using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniverseKino.WEB
{
    [Route("admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpPost("sessions")]
        public IActionResult CreateSessinons([FromBody] CreateSessionRequestModel newSession)
        {
            return Ok();
        }

        [HttpDelete("sessions/{id}")]
        public IActionResult DeleteSessinons([FromQuery] int id)
        {
            return Ok();
        }


        [HttpPost("movies")]
        public IActionResult CreateMovies([FromBody] CreateMovieRequestModel newMovie)
        {
            return Ok();
        }


        [HttpDelete("movies/{id}")]
        public IActionResult DeleteMovies([FromQuery] int id)
        {
            return Ok();
        }
    }


    public class CreateSessionRequestModel
    {
        public DateTime Date { get; set; }
        public int NumberHall { get; set; }
        public string NameMovie { get; set; }
    }

    public class CreateMovieRequestModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}
