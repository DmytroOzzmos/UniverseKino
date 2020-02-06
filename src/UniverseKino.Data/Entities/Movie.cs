using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        public int Duration { get; set; }  //stored in minutes

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
