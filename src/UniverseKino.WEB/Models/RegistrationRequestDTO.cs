namespace UniverseKino.WEB.Models
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class RegistrationRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}