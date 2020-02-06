using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Session 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        //[Required]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        //[Required]
        [ForeignKey("CinemaHall")]
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
