using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Session : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }

        [Required]
        public int IdCinemaHall { get; set; }
        public CinemaHall CinemaHall { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
