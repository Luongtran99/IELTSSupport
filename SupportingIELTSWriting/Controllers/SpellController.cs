using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SupportingIELTSWriting.Infrastructure.JsonResult;
using SupportingIELTSWriting.Infrastructure.Parser;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Controllers
{
    /*
     * All user & guest can use this function
     */



    [Route("api/[controller]")]
    [ApiController]
    public class SpellController : ControllerBase
    {
        // get Tree
        private ITernarySearchTreeRepository repository;

        private IGrammarChecker grammarChecker;

        private ILogger<SpellController> _logger;
        
        public SpellController(ITernarySearchTreeRepository repo, IGrammarChecker checker, ILogger<SpellController> logger)
        {
            repository = repo;
            grammarChecker = checker;
            _logger = logger;
        }

        // GET api/search/{word}
        [HttpGet("search/{word}")]
        public async Task<ActionResult<Result>> Search(string word)
        {
            bool checkWord = false;
            // chekc word existance
            await Task.Run(() =>
            {
                Task.Delay(1);
                checkWord = repository.Search(word);
            });
            

            if(checkWord == true)
            {
                return Ok(new Result(200, "Existed", null));
            }
            else
            {
                return NotFound(new Result(404, "Approximating word list", repository.SpWordList(word)));
            }

        }

        // GET api/spell
        // POST api/spell/checktext
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
                if( repository.Search(wrdList[i]) == true)
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

        // encrypt text
        [HttpGet("grammar/{sentence}")]
        public async Task<ActionResult<Result>> CheckGrammarSentence([FromRoute]string sentence)
        {
            if (sentence == "")
            {
                return BadRequest("Invalid sentence");
            }


            try
            {
                List<EssayErrors> result = new List<EssayErrors>();

                await Task.Run(async () =>
                {
                    Task.Delay(1);
                    result = await grammarChecker.CheckSentenceAsync(sentence);
                });
                

                if (result != null)
                {
                    return new Result(200, "check completeply", result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("error {0}", ex.Message);
            }

            // get list errors

            return new Result(300, "no error", null);


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
