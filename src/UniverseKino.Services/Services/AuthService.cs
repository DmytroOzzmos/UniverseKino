using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
using UniverseKino.WEB.Models;
using System;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UniverseKino.Services
{
    public class AuthService : IAuthService
    {
        private ApplicationContext _appContext;
        private IMapper _mapper;
        public AuthService(ApplicationContext appContext)
        {
            _mapper = new MapperConfiguration(mc =>
              {
                  mc.AddProfile(new MappingProfile());
              })
              .CreateMapper();
            _appContext = appContext;
        }

        public Task<TokenResponseDTO> Authenticate(LoginRequestDTO data)
        {
            var users = _appContext.ApplicationUsers.ToList();
            var user = _appContext.ApplicationUsers.Where(u => u.Email == data.Email).FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING")); //AppSettings.GetSymmetricAuthSecretKey();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                 new Claim[] {
                new Claim (ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim (ClaimsIdentity.DefaultRoleClaimType, user.Role),
                 },
                 "Token",
                 ClaimsIdentity.DefaultNameClaimType,
                 ClaimsIdentity.DefaultRoleClaimType
                 ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.Run(() => new TokenResponseDTO { Token = tokenHandler.WriteToken(token) });
        }

        // public async Task<OperationDetails> Create(UserDTO userDto)
        // {
        //     ApplicationUser user = await _appContext.UserManager.FindByEmailAsync(userDto.Email);
        //     if (user == null)
        //     {
        //         user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
        //         var result = await _appContext.UserManager.CreateAsync(user, userDto.Password);
        //         if (result.Errors.Count() > 0)
        //             return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
        //         // добавляем роль
        //         await _appContext.UserManager.AddToRoleAsync(user.Id, userDto.Role);
        //         // создаем профиль клиента
        //         ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
        //         _appContext.ClientManager.Create(clientProfile);
        //         await _appContext.SaveAsync();
        //         return new OperationDetails(true, "Регистрация успешно пройдена", "");
        //     }
        //     else
        //     {
        //         return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
        //     }
        // }

        // public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        // {
        //     ClaimsIdentity claim = null;
        //     // находим пользователя
        //     ApplicationUser user = await _appContext.UserManager.FindAsync(userDto.Email, userDto.Password);
        //     // авторизуем его и возвращаем объект ClaimsIdentity
        //     if (user != null)
        //         claim = await _appContext.UserManager.CreateIdentityAsync(user,
        //                                     DefaultAuthenticationTypes.ApplicationCookie);
        //     return claim;
        // }

        // // начальная инициализация бд
        // public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        // {
        //     foreach (string roleName in roles)
        //     {
        //         var role = await _appContext.RoleManager.FindByNameAsync(roleName);
        //         if (role == null)
        //         {
        //             role = new ApplicationRole { Name = roleName };
        //             await _appContext.RoleManager.CreateAsync(role);
        //         }
        //     }
        //     await Create(adminDto);
        // }

        public void Dispose()
        {
            _appContext.Dispose();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TokenResponseDTO> Register(RegistrationRequestDTO data)
        {
            var user = _appContext.ApplicationUsers.Where(u => u.Email == data.Email).FirstOrDefault();

            if (user != null)
            {
                throw new Exception();
            }

            var newUser = _mapper.Map<ApplicationUser>(data);

            newUser.Role = "User";

            _appContext.ApplicationUsers.Add(newUser);
            _appContext.SaveChangesAsync();

            return
             Task.Run(() => new TokenResponseDTO
             {
                 Token = newUser.Username
             });
        }


    }
}