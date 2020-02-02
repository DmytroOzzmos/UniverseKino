using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int Duration { get; set; }  //stored in minutes

        public List<Session> Sessions { get; set; }
    }
}
