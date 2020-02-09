using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Services.Dto
{
    public class CreateSessionDTO
    {
        public DateTime Date { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}
