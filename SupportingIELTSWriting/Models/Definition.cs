using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Definition
    {
        [Key]
        public string definitionId { get; set; }
        public string definition { get; set; }
        public string example { get; set; }
        public string meaningId { get; set; }
        public Meaning Meaning { get; set; }
        public IList<string> synonyms { get; set; } = new List<string>();
    }
}

