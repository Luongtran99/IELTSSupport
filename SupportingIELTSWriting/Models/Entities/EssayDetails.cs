using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class EssayDetails
    {
        public string EssayID { get; set; }
        public Essay Essay { get; set; }
        //public float EssayPoint { get; set; }
        public int ViewCount { get; set; }
        public int ErrorCount { get; set; }
        public int CommentCount { get; set; }
        
    }
}
