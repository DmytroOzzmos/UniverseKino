using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class CreateMovieRequestModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid name length")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Invalid genre")]
        public string Genre { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Invalid duration movie")]
        public int Duration { get; set; }
    }
}
