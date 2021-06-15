using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    public class CreateEssayRequest
    {
        public string Text { get; set; }
        public string Topic { get; set; }
    }
}
