using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class Role : IdentityRole
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
