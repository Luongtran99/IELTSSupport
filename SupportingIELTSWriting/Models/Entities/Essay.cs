using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    public class Essay
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public DateTime theLastFixingTime { get; set; }
        public bool isDeleted { get; set; } = false;
        public string userId { get; set; }
        public User User { get; set; }
        public string historyId { get; set; }
        public bool isPublish { get; set; } = true;
        public ICollection<History> History { get; set; } = new List<History>();
        //public ICollection<EssayErrors> essayErrors { get; set; } = new List<EssayErrors>();
        public ICollection<Notes> Notes { get; set; } = new List<Notes>();
    }
}
