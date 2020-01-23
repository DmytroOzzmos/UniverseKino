using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public AuthController(IAuthService authServ)
        {
            _authServ = authServ;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestDTO data)
        {
            var token = await _authServ.Register(data.Email, data.Password);

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

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestDTO data)
        {
            var token = await _authServ.Authenticate(data.Email, data.Password);

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