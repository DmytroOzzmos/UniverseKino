using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniverseKino.WEB
{
    public class CreateSessionRequestModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}
