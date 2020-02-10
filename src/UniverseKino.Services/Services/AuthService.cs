using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniverseKino.Data.EF;
using UniverseKino.Data.Entities;
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
using UniverseKino.Data.Interfaces;
using UniverseKino.Services.Exceptions;
using UniverseKino.Services.Dto;

namespace UniverseKino.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _userRepository;
        private JWTHelper _jwt;
        private IMapper _mapper;
        private SymmetricSecurityKey key;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        private PasswordHasher _hasher;

        public AuthService(IAuthRepository userRepository, IOptionsMonitor<JWTHelper> jwt, PasswordHasher hasher, IMapper mapper)
        {
            _mapper = mapper;
            _jwt = jwt.CurrentValue;
            _userRepository = userRepository;
            _hasher = hasher;
            key = _jwt.GetSecretKey();
        }

        public List<UserDTO> AllUsers()
        {
            var users = _userRepository.GetAll().ToList();

            var usersDTO = _mapper.Map<List<UserDTO>>(users);

            return usersDTO;
        }

        public Task<TokenResponseDTO> Authenticate(RegistrationRequestDTO data)
        {
            var user = _userRepository
                        .FindByPredicate(u => u.Email == data.Email && _hasher.Check(u.Password, data.Password))
                        .FirstOrDefault();

            if (user == null)
            {
                throw new Exception();
            }

            var tokenDescriptor = GetTokenDescriptor(user);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.Run(() => new TokenResponseDTO { Token = tokenHandler.WriteToken(token) });
        }


        public async Task<TokenResponseDTO> Register(RegistrationRequestDTO data)
        {
            var user = _userRepository
                    .FindByPredicate(u => u.Email == data.Email)
                    .FirstOrDefault();

            if (user != null)
            {
                throw new EntityAlreadyExistsException("User already exist");
            }

            var newUser = _mapper.Map<ApplicationUser>(data);

            newUser.Role = "User";
            newUser.Password = _hasher.Hash(data.Password);

            await _userRepository.AddAsync(newUser);

            var tokenDescriptor = GetTokenDescriptor(newUser);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponseDTO { Token = tokenHandler.WriteToken(token) };
        }

        private SecurityTokenDescriptor GetTokenDescriptor(ApplicationUser user)
        {
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

            return tokenDescriptor;
        }
    }
}