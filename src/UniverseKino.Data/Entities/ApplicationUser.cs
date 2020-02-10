using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseKino.Data.Entities
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
