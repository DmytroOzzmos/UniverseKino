using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniverseKino.Data.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public int IdSession { get; set; }
        public Session Session { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
