using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class EssayErrors
    {
        public string Message { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<string> Replacements { get; set; }

    }
}
