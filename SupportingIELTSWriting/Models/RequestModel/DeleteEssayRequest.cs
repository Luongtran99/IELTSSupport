using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.RequestModel
{
    public class DeleteEssayRequest
    {
        public int essayId { get; set; }
        public bool isDeleted { get; set; }

    }
}
