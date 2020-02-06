using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class Session 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int CinemaHallId { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
