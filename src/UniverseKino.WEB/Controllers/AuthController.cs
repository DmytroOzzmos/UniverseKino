using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services;
using UniverseKino.WEB.Filters;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("users")]
        public IActionResult AllUsers() => Ok(_authService.AllUsers());

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestView data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RegisterServiceDTO = _mapper.Map<RegistrationRequestDTO>(data);

            var token = await _authService.Register(RegisterServiceDTO);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequestView data)
        {
            var serviceModel = _mapper.Map<RegistrationRequestDTO>(data);
            var token = await _authService.Authenticate(serviceModel);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);
        }
    }
}
