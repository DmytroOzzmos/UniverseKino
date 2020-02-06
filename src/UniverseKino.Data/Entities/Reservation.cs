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

        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        [ForeignKey("Session")]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public Boolean Paid { get; set; }

        [ForeignKey("UserName")]
        public int UserId { get; set; }
        public ApplicationUser UserName { get; set; }
    }
}
