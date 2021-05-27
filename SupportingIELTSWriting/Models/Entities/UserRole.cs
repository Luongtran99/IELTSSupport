using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public Roles Role { get; set; }
        public User User { get; set; }
    }
}
