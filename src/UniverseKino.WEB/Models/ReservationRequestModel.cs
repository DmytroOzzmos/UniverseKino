using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class ReservationRequestModel
    {
        public int Number { get; set; }
        public int Row { get; set; }
        public int SessionId { get; set; }
    }
}
