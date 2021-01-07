using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SupportingIELTSWriting.Infrastructure.JsonResult;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        // get Tree
        private ITernarySearchTreeRepository repository;
        public SpellController(ITernarySearchTreeRepository repo)
        {
            repository = repo;
        }

        // GET api/search/{word}
        [HttpGet("search/{word}")]
        public ActionResult Search(string word)
        {
            // chekc word existance
            bool checkWord =  repository.Search(word);

            if(checkWord == true)
            {
                return Ok(new Result(200, "Existed", null));
            }
            else
            {
                return NotFound(new Result(404, "Approximating word list", repository.SpWordList(word)));
            }

        }
        // GET api/spell/checktext
        [HttpPost("checktext")]
        public async Task<ActionResult<Result>> CheckAllText([FromBody]JObject value)
        {
            // split text
            char[] defaultCharaters = { '.', ',', '?', '|', '{', '}', '[', ']', ':', ';', '\"', '\'','!','@','#','$','%','^','&','*','(',')'
            ,'~','`','_','+','+','1','2','3','4','5','6','7','8','9','0',' '};

            string[] wrdList = value.GetValue("value").ToString().Split(defaultCharaters);

            Dictionary<string, List<Word>> keyValues = new Dictionary<string, List<Word>>();

            for (var i = 0; i < wrdList.Length; i++)
            {
                if(repository.Search(wrdList[i]) == true)
                {
                    continue;
                }
                else
                {
                    keyValues.Add(wrdList[i], repository.SpWordList(wrdList[i]));
                }
            }

            // check text 
            return new Result(200, "auto complete word", keyValues);
        }

        
        // POST api/spell
        [HttpPost]
        [Consumes("application/json")]
        public ActionResult Post([FromBody]Word word)
        {



            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
