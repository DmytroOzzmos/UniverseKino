using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Services.Dto
{
    public class SessionDTO
    {
        public DateTime Date { get; set; }

        public string NameMovie { get; set; }

        public string GenreMovie { get; set; }

        public int DurationMovie { get; set; }

        public int NumberHall { get; set; }

        public List<SeatDTO> Seats { get; set; }
    }
}
