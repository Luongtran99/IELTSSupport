using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    []
    public class AccountController : ControllerBase
    {
        private IIdentityServices _services;
        
        public AccountController(IIdentityServices services)
        {
            _services = services;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequestModel request)
        {
            try
            {
                var authResponse = await _services.LoginAsync(request.Username, request.Password, request.RememberMe);

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
            catch(Exception ex)
            {
                return NotFound(new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { ex.Message }
                });
            }
        }

        // Handle postback from username/password register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequestModel request)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { ex.Message }
                });
            }
            
        }

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            var x = await _services.LogoutAsync();
            return Ok(new AuthResult
            {
                Token = null,
                isSuccess = true,
                Message = new string[] { "Logout completely" }
            });
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword([FromRoute] string newPassword)
        {
            // get current user 
            
            return null;
        }
    }
}
