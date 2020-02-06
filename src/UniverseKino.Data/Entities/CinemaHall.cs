using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class CinemaHall
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
