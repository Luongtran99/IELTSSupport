using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Area.Admin.Models
{
    public class RequestInfo
    {
        
        public string UrlPath { get; set; }
        public bool checkRules { get; set; }
    }
}
