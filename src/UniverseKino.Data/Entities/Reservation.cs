using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }

        public Boolean Paid { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser UserName { get; set; }
    }
}
