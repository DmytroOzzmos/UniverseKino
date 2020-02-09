using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Services.Dto
{
    public class CreateSassionDTO
    {
        public DateTime Date { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}
