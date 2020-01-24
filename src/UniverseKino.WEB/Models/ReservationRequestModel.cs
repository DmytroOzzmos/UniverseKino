using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class ReservationRequestModel
    {
        public int SessionsId { get; set; }
        public List<Place> PlacesToBook { get; set; }
    }
}
