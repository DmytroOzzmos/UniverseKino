using System;
using System.ComponentModel.DataAnnotations;
using UniverseKino.Core;

namespace UniverseKino.WEB.Models
{
    public class RegistrationRequestView
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email address invalid")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }

        [StringLength(25, MinimumLength = 5, ErrorMessage = "Username invalid")]
        public string UserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "First name invalid")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Last name invalid")]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [RegularExpression(@"^[+][3][8]\d{10}$")]
        public string PhoneNumber { get; set; }
    }
}