using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB.Models
{
    public class SessionModel
    {
        public DateTime Date { get; set; }

        public string NameMovie { get; set; }

        public string GenreMovie { get; set; }

        public int DurationMovie { get; set; }

        public int NumberHall { get; set; }

        public List<SeatModel> Seats { get; set; }
    }
}
