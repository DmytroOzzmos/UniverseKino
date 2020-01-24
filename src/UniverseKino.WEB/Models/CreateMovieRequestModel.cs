using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class CreateMovieRequestModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}
