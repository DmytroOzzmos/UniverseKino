using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Seat : BaseEntity
    {
        [Required]
        public int IdCinemaHall { get; set; }
        public CinemaHall CinemaHall { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
