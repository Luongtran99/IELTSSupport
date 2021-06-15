using Newtonsoft.Json;
using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public static class GetMeanWordAPI
    {
        public static async Task<Word> ValueAsync(string word, string popularCount)
        {



            HttpClient client = new HttpClient();

            //HttpWebRequest request = WebRequest.Create("https://api.dictionaryapi.dev/api/v2/entries/en/" + word) as HttpWebRequest;

            var resp = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.dictionaryapi.dev/api/v2/entries/en/" + word));

            string jsonValue = "";List<Word> list = null;
            using (HttpResponseMessage response = resp)
            {
                if(resp.StatusCode == HttpStatusCode.NotFound)
                {
                    Word _word = new Word();
                    _word.word = word;
                    _word.popularCount = popularCount;
                    return _word;
                }
                else
                {
                    using (HttpContent content = response.Content)
                    {
                        jsonValue = content.ReadAsStringAsync().Result;
                        list = JsonConvert.DeserializeObject<List<Word>>(jsonValue);
                        Word wrd = new Word();
                        foreach (var x in list)
                        {
                            wrd.word = word;
                            wrd.phonetics = x.phonetics;
                            wrd.meanings = x.meanings;
                            wrd.popularCount = popularCount;
                        }
                        list = null; // free memory
                        return wrd;
                    }
                }

            }
        }
    }
}
