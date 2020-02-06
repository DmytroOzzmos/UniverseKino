using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
