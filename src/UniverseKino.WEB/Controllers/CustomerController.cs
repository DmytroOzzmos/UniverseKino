using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseKino.WEB
{
    [Route("customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {

        /// <summary>
        /// можно троечку,пожалуйста))Ц
        /// </summary>
        
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
        public async  Task<IActionResult> ToBook ([FromBody] BookRequestModel places)
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
    
    public class BookRequestModel
    {
        public int SessionsId { get; set; }
        public List<Place> PlacesToBook { get; set; }
    }

    public class Place
    {
        public int NumberSeat { get; set; }
        public int NumberRow { get; set; }
    }
    
}
