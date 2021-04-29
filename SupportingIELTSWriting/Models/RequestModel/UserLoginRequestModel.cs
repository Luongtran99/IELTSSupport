using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    public class UserLoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
