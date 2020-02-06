using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class Seat 
    {
        [Key]
        public int Id { get; set; }

        public int IdCinemaHall { get; set; }
        public virtual CinemaHall CinemaHall { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }
    }
}
