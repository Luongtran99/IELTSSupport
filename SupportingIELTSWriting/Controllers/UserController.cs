using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportingIELTSWriting.Infrastructure;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var x = await _userServices.GetUserAsync(HttpContext.GetUserId());

            if (x == null)
            {
                return NotFound(new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { "User is not existed" }
                });
            }

            return Ok(x);
        }

        // get info of the other user
        [HttpGet("{userId}")]
        public async Task<ActionResult> Get(string userId)
        {
            var x = await _userServices.GetUserAsync(userId);

            if (x == null)
            {
                return NotFound(new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { "User is not existed" }
                });
            }

            return Ok(x);
        }

        [HttpPost("edit")]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            var _user = new User
            {
                Id = HttpContext.GetUserId(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                
            };

            var updated = await _userServices.EditUserAsync(_user);

            if (updated)
            {
                return Ok(_user);
            }

            return NotFound();
        }


    }
}
