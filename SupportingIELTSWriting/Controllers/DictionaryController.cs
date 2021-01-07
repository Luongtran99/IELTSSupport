using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Infrastructure.JsonResult;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/dictionary")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private IWordServices context;
        public DictionaryController(IWordServices ct)
        {
            this.context = ct;
        }

        // GET: api/Dictionary
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Dictionary/5
        [HttpGet("{word}")]
        public async Task<ActionResult> GetMeanByWord(string word)
        {
            if(word == null || word == "")
            {
                return NotFound(new Result(400, "No word value", null));
            }
            // get word from database   
            var _word = context.GetWord(word);

            if(_word == null)
            {
                var x = await GetMeanWordAPI.ValueAsync(word, null);

                // add to database 
                await context.AddWordAsync(x);
               
                return Ok(new Result(200, "Found", context.GetWord(word)));
            }
            else
            {
                return Ok(new Result(200, "Found", _word));

            }

        }

        // POST: api/Dictionary
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "Hello";
        }

        // PUT: api/Dictionary/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
