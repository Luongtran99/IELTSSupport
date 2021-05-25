using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class UserRole
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
