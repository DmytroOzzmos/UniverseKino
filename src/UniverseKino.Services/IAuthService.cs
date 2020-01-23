using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services
{
    public interface IAuthService
    {
        Task<string> Register(string email, string password);
        Task<string> Authenticate(string username, string password);
        IEnumerable<ApplicationUser> GetAll();
        // Task<OperationDetails> Create(UserDTO userDto);
        // Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        // Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}