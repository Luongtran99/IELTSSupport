using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.ResponseModel
{

    public class Result
    {
        public string id { get; set; }
        public string topic { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }

        public Result()
        {
        }
    }
    public class ResponseGetAllEssayList
    {
        public int currentPage { get; set; }
        public int nextPage { get; set; }
        public List<Result> essays { get; set; }
        public int noOfEssays { get; set; }
    }
}
