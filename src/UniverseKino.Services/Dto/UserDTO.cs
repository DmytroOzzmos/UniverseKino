using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseKino.Services.Dto
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
    }
}
