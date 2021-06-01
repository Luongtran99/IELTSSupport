using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.ViewModels
{
    public class PagingInfo
    {
        public int currentPage { get; set; }
        public int essaysPerPage { get; set; }
        public int totalEssays { get; set; }
        public int totalPages => (int)Math.Ceiling((decimal)totalEssays / essaysPerPage);
    }
}
