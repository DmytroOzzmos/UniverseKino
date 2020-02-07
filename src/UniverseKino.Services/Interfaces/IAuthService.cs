using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDTO> Register(RegistrationRequestDTO data);
        Task<TokenResponseDTO> Authenticate(LoginRequestDTO data);

        List<dynamic> AllUsers();
        IEnumerable<ApplicationUser> GetAll();
        // Task<OperationDetails> Create(UserDTO userDto);
        // Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        // Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}