using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }
        public bool isDeleted { get; set; } = false;

        public string ProfileImage { get; set; } = null; 
        public ICollection<Essay> Essays { get; set; } = new List<Essay>();
        public ICollection<History> Histories { get; set; } = new List<History>();


        
    }
}
