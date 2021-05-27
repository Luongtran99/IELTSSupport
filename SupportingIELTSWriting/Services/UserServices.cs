using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SupportingIELTSWriting.Infrastructure;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        public UserServices(UserManager<User> userManager, IHostingEnvironment env)
        {
            _userManager = userManager;
            hostingEnvironment = env;
        }

        public async Task<bool> EditUserAsync(User user)
        {
            var exist = await _userManager.UpdateAsync(user);
            if (exist.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var exit = await _userManager.FindByIdAsync(userId);

            if(exit == null)
            {
                return null;
            }

            return exit;
        }

        public async Task<AuthResult> UpdateAvatarAsync(string id , IFormFile file)
        {
            // upload image
            //var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //var extension = Path.GetExtension(file.FileName);
            //var contentType = file.ContentType;

            // get webroot path
            var uploadFolders = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string uniqueFileName = id + "_" + file.FileName;
            string filePath = Path.Combine(uploadFolders, uniqueFileName);
            using (var memoryStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(memoryStream);

                // upload only one 
                if (memoryStream.Length < 2097152)
                {
                    var user = await _userManager.FindByIdAsync(id);
                    user.ProfileImage = uniqueFileName;

                    // update
                    var checkUpdate = await _userManager.UpdateAsync(user);
                    return checkUpdate.Succeeded ? new AuthResult
                    {
                        isSuccess = true,
                        Message = new string[] { "File uploaded completely" }
                    } :
                    new AuthResult
                    {
                        isSuccess = false,
                        Message = new string[] { "File uploaded error! " }
                    };
                }
                else
                {
                    return new AuthResult
                    {
                        isSuccess = false,
                        Message = new string[] { "File is too large !" }
                    };
                }
            }
        }
    }
}
