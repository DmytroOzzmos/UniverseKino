using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.Entities;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDTO> Register(RegistrationRequestDTO data);
        Task<TokenResponseDTO> Authenticate(RegistrationRequestDTO data);

        List<UserDTO> AllUsers();
    }
}