using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = "Member")]
    [Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // get info of the other user
        [HttpGet()]
        public async Task<ActionResult> GetInforByIdAsync()
        {

            var userId = HttpContext.GetUserId();

            var getUserInfo = await _userServices.GetUserAsync(userId);

            if (getUserInfo == null)
            {
                return NotFound(new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { "User is not existed" }
                });
            }

            return Ok(getUserInfo);
        }

        [HttpPost("edit")]
        public async Task<ActionResult> UpdateAsync([FromBody] User user)
        {
            // check user is correct type
            //HttpContext a = new HttpContext();
            

            var _user = new User
            {
                Id = HttpContext.GetUserId(),
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Bio = user.Bio,
                WebSite = user.WebSite,
                Gender = user.Gender
            };
            try
            {
                var updated = await _userServices.EditUserAsync(_user);

                if (updated)
                {
                    return Ok(_user);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("edit_avatar")]
        public async Task<AuthResult> UpdateAvatarAsync()
        {

            try
            {
                var file = Request.Form.Files[0];
                var id = HttpContext.GetUserId();
                var getResult = await _userServices.UpdateAvatarAsync(id, file);
                return  getResult;
            }
            catch(Exception ex)
            {
                return new AuthResult
                {
                    isSuccess = false,
                    Message = new string[] { $"Internal server error: {ex}" }
                };
            }
        }
    }
}
