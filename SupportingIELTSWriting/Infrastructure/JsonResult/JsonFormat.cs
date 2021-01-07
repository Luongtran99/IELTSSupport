using SupportingIELTSWriting.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SupportingIELTSWriting.Infrastructure.JsonResult
{
    public static class JsonFormat
    {
        // convert string List to Object List
        public static List<Word> ConvertStringToObject(List<string> wrdList)
        {
            if(wrdList == null)
            {
                throw new ArgumentException("Opps! Some thing wrong, Please check your word");
            }

            List<Word> bufList = new List<Word>();

            wrdList.ForEach(str =>
            {
                bufList.Add(new Word
                {
                    word = str,
                });
            });

            return bufList;
        }

        public static string toJSON(object obj)
        {
            string s = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return s;
            
        }
    }
}
