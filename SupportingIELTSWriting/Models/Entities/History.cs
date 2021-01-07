using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class History
    {
        public string id { get; set; }
        public DateTime DateTime { get; set; }
        public string userId { get; set; }
        public string essayId { get; set; }
        public User User { get; set; }
        public Essay Essay { get; set; }
        public string oldEssay { get; set; }
        public string newEssay { get; set; } 
        public bool isDeleted { get; set; } = false;

    }
}
