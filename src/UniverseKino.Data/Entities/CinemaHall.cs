using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class CinemaHall : BaseEntity
    {
        [Required]
        public int Number { get; set; }

        public List<Seat> Seats { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
