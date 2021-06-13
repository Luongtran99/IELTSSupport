using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    public class ChangePasswordRequest
    {
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
