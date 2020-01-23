using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;

namespace UniverseKino.Services
{
    public class AuthService : IAuthService
    {
        private ApplicationContext _appContext;
        public AuthService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await Task.Run(() =>
                    _appContext
                   .ApplicationUsers
                   .Where(user => user.Username == username
                   && user.Password == password)
                   .FirstOrDefault()
            );

            return "";
        }

        public async Task<string> Register(string email, string password)
        {

            var user = await Task.Run(() =>
                    _appContext
                   .ApplicationUsers
                   .Where(user => user.Email == email)
                   .FirstOrDefault()
            );

            return "";

        }

        // public async Task<string> Register(UserDTO userDTO)
        // {
        //     ApplicationUser user = await _appContext.ApplicationUsers.Where(user => user.Email == userDTO.Email);

        //     return "";
        // }

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

        public string Register(UserDTO newUser)
        {
            return "";
        }


    }
}