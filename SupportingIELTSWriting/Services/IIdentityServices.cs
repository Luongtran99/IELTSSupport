﻿using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public interface IIdentityServices
    {
        Task<AuthResult> RegisterAsync(string email, string password);
        Task<AuthResult> LoginAsync(string email, string password, bool rememberMe);
        Task<bool> LogoutAsync();
        Task<AuthResult> ChangePassword(string userId,string currentPassword, string pasword);
    }
}
