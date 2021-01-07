using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.RequestModel;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IIdentityServices _services;
        
        public AccountController(IIdentityServices services)
        {
            _services = services;
        }


       [HttpPost("register")]
       public async Task<IActionResult> Register([FromBody]UserRegistrationRequestModel request)
       {

            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult
                {
                    Message = ModelState.Values.SelectMany(p => p.Errors.Select(x => x.ErrorMessage))
                });
            }

            var authResponse = await _services.RegisterAsync(request.Email, request.Password);

            if (!authResponse.isSuccess)
            {
                return BadRequest(new AuthResult
                {
                    Message = authResponse.Message
                });

            }

            return Ok(new AuthResult
            {
                Token = authResponse.Token,
                isSuccess = true,
                Message = new string[] { "Got token completely!" }
            });
       }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequestModel request)
        {
            var authResponse = await _services.LoginAsync(request.Username, request.Password);

            if (!authResponse.isSuccess)
            {
                return BadRequest(new AuthResult
                {
                    Message = authResponse.Message
                });

            }

            return Ok(new AuthResult
            {
                Token = authResponse.Token,

                isSuccess = true,
                Message = new string[] { "Login completely" }
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var x = await _services.LogoutAsync();
            return Ok(new AuthResult
            {
                Message = new string[] { "Logout completely" }
            });
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromRoute] string newPassword)
        {
            return null;
        }
    }
}
