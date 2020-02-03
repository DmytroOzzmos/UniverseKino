using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Reservation : BaseEntity
    {
        public int IdSeat { get; set; }
        public Seat Seat { get; set; }

        public int IdSession { get; set; }
        public Session Session { get; set; }

        public Boolean Paid { get; set; }
        public int IdUser { get; set; }
        public ApplicationUser UserName { get; set; }
    }
}
