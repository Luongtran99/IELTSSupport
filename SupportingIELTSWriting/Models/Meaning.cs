using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Meaning
    {
        [Key]
        public string meaningId { get; set; }
        public string partOfSpeech { get;set; }
        public string wordId { get; set; }
        public Word Word { get; set; }
        public IList<Definition> definitions { get; set; } = new List<Definition>();
    }
}
