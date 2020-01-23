using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services;
using UniverseKino.WEB.Models;

namespace UniverseKino.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authServ;
        private IMapper _mapper;
        public AuthController(IAuthService authServ, IMapper mapper)
        {
            _authServ = authServ;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestView data)
        {
            var RegisterServiceDTO = _mapper.Map<RegistrationRequestDTO>(data);
            var token = await _authServ.Register(RegisterServiceDTO);

            if (token == null)
            {
                return BadRequest();
            }

            else
                return Ok(
                    new TokenResponseView
                    {
                        Token = token.Token
                    }
                    );
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequestView data)
        {
            var serviceModel = new LoginRequestDTO(); /*_mapper.Map<LoginRequestDTO>(data);*/
            var token = await _authServ.Authenticate(serviceModel);

            if (token == null)
            {
                return BadRequest();
            }

            else
                return Ok(
                    new
                    {
                        Token = token
                    }
                    );
        }
    }
}