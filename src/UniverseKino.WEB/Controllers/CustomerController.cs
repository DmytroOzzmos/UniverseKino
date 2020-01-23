using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.WEB.View;

namespace UniverseKino.WEB
{
    [Route("customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        [HttpGet("schedule")]
        public async  Task<IActionResult> GetAllSessions()
        {
            return await Task.Run( () => Ok("Go to the nahuy"));
        }

        [HttpGet("sessions/{id}")]
        public async  Task<IActionResult> GetSession([FromQuery] int id)
        {
            return await Task.Run( () => Ok());
        }

        [HttpPost("sessions/tobook")]
        public async  Task<IActionResult> ToBook ([FromBody] ReservationRequestModel places)
        {
            return await Task.Run( () => Ok());
        }

        [HttpGet("movies")]
        public async  Task<IActionResult> GetAllMovies()
        {
            return await Task.Run( () => Ok());
        }

        [HttpGet("movies/{id}")]
        public async  Task<IActionResult> GetSMovie([FromQuery] int id)
        {
            return await Task.Run( () => Ok());
        }

        [HttpGet("movies/{id}/sessions")]
        public async  Task<IActionResult> GetSessionsMovie([FromQuery] int id)
        {
            return await Task.Run( () => Ok());
        }
    }
}
