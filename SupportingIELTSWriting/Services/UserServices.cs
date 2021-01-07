using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;
        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
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
    }
}
