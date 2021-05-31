using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class AuthResult
    {
        public string code { get; set; }
        public string Token { get; set; }
        public string userId { get; set; }
        public bool isSuccess { get; set; }
        public IEnumerable<string> Message { get; set; }
    }
}
