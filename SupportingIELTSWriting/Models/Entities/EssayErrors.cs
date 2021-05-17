using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models.Entities
{
    // 
    public class EssayErrors
    {
        public string Message { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<string> Replacements { get; set; }
        public int essayId { get; set; }
        public Essay Essay { get; set; }

        public EssayErrors()
        {
            Replacements = new List<string>();
        }

        public EssayErrors(string result)
        {
            Replacements = new List<string>();

            string[] array = result.Split('|');

            From = Convert.ToInt32(array[0]);
            To = Convert.ToInt32(array[1]);

            Message = array[2];

            Replacements = splitReplacementStr(array[3]);
        }

        public List<string> splitReplacementStr(string replacementStr)
        {
            string splitStr = replacementStr.Replace('\'', ' ').Replace('[', ' ').Replace(']', ' ').Replace('\"', ' ').Replace('\r', ' ');

            return splitStr.Split(',').ToList();
        }
    }
}
