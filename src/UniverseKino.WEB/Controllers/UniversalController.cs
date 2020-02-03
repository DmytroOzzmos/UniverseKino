using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.WEB.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniverseKino.WEB.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UniversalController : ControllerBase
    {
        private readonly UniverseKinoContext _context;

        public UniversalController(UniverseKinoContext context)
        {
            _context = context;
        }

        [HttpPost("reservation")]
        public IActionResult ToBook([FromBody] ReservationRequestModel reservation)
        {
            var user = _context.GetUserFromToken(User);

            var session = _context.Sessions.Where(x => x.Id == reservation.SessionId).FirstOrDefault();

            var seat = session.CinemaHall.Seats.Where(x => x.Number == reservation.Number && x.Row == reservation.Row).FirstOrDefault();

            if (session.IsBusySeat(seat.Id))
            {
                return BadRequest("place already taken");
            }

            Reservation saveReserv = new Reservation
            {
                IdSeat = seat.Id,
                IdSession = session.Id,
                IdUser = user.Id,
                Paid = false
            };

            _context.Reservations.Add(saveReserv);

            return Ok();
        }

        [HttpPost("reservation/{id}/payment")]
        public IActionResult Pay([FromRoute] int id)
        {
            return Ok();
        }
    }
}
