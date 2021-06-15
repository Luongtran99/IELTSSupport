using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class Notes
    {
        public int NotesId { get; set; }
        public string Sentence { get; set; }
        public string Mean { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string EssayId { get; set; }
        public Essay Essay { get; set; }
    }
}
