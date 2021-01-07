using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public interface IUserServices
    {
        Task<User> GetUserAsync(string userId);
        Task<bool> EditUserAsync(User user);
    }
}
