using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class CreateSessionRequestModel
    {
        public DateTime Date { get; set; }
        public int NumberHall { get; set; }
        public string NameMovie { get; set; }
    }
}
