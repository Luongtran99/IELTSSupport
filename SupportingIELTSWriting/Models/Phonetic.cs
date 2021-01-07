using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Phonetic
    {
        [Key]
        public string phoneticId { get; set; }
        public string text { get; set; } 
        public string audio { get; set; } // base64
        public string wordId { get; set; }
        public Word Word { get; set; }
    }
}
