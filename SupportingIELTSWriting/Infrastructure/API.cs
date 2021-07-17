using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Infrastructure
{
    public static class API
    {
        public static class Account
        {
            public static string Login(string baseUrl) => $"{baseUrl}/api/account/login";
            public static string Register(string baseUrl) => $"{baseUrl}/api/account/register";
            public static string Logout(string baseUrl) => $"{baseUrl}/api/account/logout";

        }

        public static class User
        {
            public static string GetUser(string baseUrl) => $"{baseUrl}/api/user";
            public static string GetUserById(string baseUrl, string id) => $"{baseUrl}/api/user/{id}";
            
        }
    }
}
