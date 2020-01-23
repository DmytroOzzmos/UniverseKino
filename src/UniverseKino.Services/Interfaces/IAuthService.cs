using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.WEB.Models;

namespace UniverseKino.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDTO> Register(RegistrationRequestDTO data);
        Task<TokenResponseDTO> Authenticate(LoginRequestDTO data);
        IEnumerable<ApplicationUser> GetAll();
        // Task<OperationDetails> Create(UserDTO userDto);
        // Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        // Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}