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
using Microsoft.AspNetCore.Identity;
using UniverseKino.Services.Services;
using Microsoft.Extensions.Options;
using UniverseKino.Core;
using UniverseKino.Data.Repositories;

namespace UniverseKino.Services
{
    public class AuthService : IAuthService
    {
        private AuthRepository _userRepo;
        private JWTHelper _jwt;
        private IMapper _mapper;
        private SymmetricSecurityKey key;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        private PasswordHasher _hasher;

        public AuthService(AuthRepository userRepo, IOptionsMonitor<JWTHelper> jwt, PasswordHasher hasher, IMapper mapper)
        {
            _mapper = mapper;
            _jwt = jwt.CurrentValue;
            _userRepo = userRepo;
            _hasher = hasher;
            key = _jwt.GetSecretKey();
        }

        public Task<TokenResponseDTO> Authenticate(LoginRequestDTO data)
        {

            var user = _userRepo.Users
                        .Where(u => u.Email == data.Email && _hasher.Check(u.Password, data.Password))
                        .FirstOrDefault();

            if (user == null)
            {
                throw new Exception();
            }

            // var tokenHandler = new JwtSecurityTokenHandler();
            // var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING")); //AppSettings.GetSymmetricAuthSecretKey();
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



        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userRepo.Users;
        }

        public async Task<TokenResponseDTO> Register(RegistrationRequestDTO data)
        {
            // var user = await Task.Run(() =>
            // _appContext.ApplicationUsers.Where(u => u.Email == data.Email).FirstOrDefault();
            // );

            var user = _userRepo.Users
                    .Where(u => u.Email == data.Email)
                    .FirstOrDefault();

            if (user != null)
            {
                throw new Exception();
            }

            var newUser = _mapper.Map<ApplicationUser>(data);

            newUser.Role = "User";
            newUser.Password = _hasher.Hash(data.Password);

            _userRepo.Users.Add(newUser);
            await _userRepo.SaveChangesAsync();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                             new Claim[] {
                new Claim (ClaimsIdentity.DefaultNameClaimType, newUser.Username),
                new Claim (ClaimsIdentity.DefaultRoleClaimType, newUser.Role),
                             },
                             "Token",
                             ClaimsIdentity.DefaultNameClaimType,
                             ClaimsIdentity.DefaultRoleClaimType
                             ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponseDTO { Token = tokenHandler.WriteToken(token) };
        }


    }
}