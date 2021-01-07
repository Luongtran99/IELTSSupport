using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    public class UpdateEssayRequest
    {
        public string Text { get; set; }
        public string oldText { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
