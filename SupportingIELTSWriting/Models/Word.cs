using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Word
    {
        [Key]
        public string wordId { get; set; }
        [Required]
        [MaxLength(50)]
        public string word { get; set; }
        [Required]
        [MaxLength(100)]
        public string popularCount { get; set; }
        public virtual IList<Meaning> meanings { get; set; } = new List<Meaning>();
        public virtual IList<Phonetic> phonetics { get; set; } = new List<Phonetic>();

        
    }
}
