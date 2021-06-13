using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Infrastructure;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Models.RequestModel;
using SupportingIELTSWriting.Models.ResponseModel;
using SupportingIELTSWriting.Services;
using Result = SupportingIELTSWriting.Models.ResponseModel.Result;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Member")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EssayController : ControllerBase
    {
        private readonly IEssayServices _essayServices;
        private readonly IHistoryServices _historyServices;
        private readonly DictionaryDbContext context;
        private readonly ILogger<EssayController> _logger;


        public EssayController(IEssayServices es, IHistoryServices historyServices, ILogger<EssayController> logger, DictionaryDbContext ct)
        {
            _essayServices = es;
            _historyServices = historyServices;
            _logger = logger;
            context = ct;
        }

        //[Route("[action]/{pageNumber}")]
        [HttpGet("essays/{pageNumber}")]
        public async Task<IActionResult> GetEssayPopular([FromRoute]int pageNumber)
        {
            int setPage = Convert.ToInt32(pageNumber);

            List<Essay> getListEssay = new List<Essay>();
            try
            {
                getListEssay = await _essayServices.getAllEssays(pageNumber);

                List<Result> result = new List<Result>();
                foreach(var p in getListEssay)
                {
                    Result a = new Result();
                    a.id = p.Id;
                    a.topic = p.Topic;
                    a.content = p.Text;
                    a.date = p.Date.Date;
                    a.username = context.Users.First(c => c.Id == p.userId || p.userId == null).LastName;
                    result.Add(a);
                }



                if (getListEssay == null)
                {
                    return NotFound(new ResponseGetAllEssayList
                    {
                        currentPage = setPage,
                        nextPage = setPage + 1,
                        essays = null,
                        noOfEssays = 0
                    });
                }

                return Ok(new ResponseGetAllEssayList
                {
                    currentPage = setPage,
                    nextPage = setPage + 1,
                    noOfEssays = getListEssay.Count(),
                    essays = result
                });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return null;
        }

        /// <summary>
        /// Get all esays owned indiviually
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllEssays()
        {
            return Ok(await _essayServices.GetEssaysAsync(HttpContext.GetUserId()));
        }

        /// <summary>
        /// Get list history of essay changed
        /// </summary>
        /// <param name="essayId"></param>
        /// <returns></returns>
        [HttpGet("history/{essayId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetEssayHistoryAsync([FromRoute] string essayId)
        {
            try
            {
                var essayHistory = await _essayServices.GetHistoriesByEssayIdAsync(essayId);

                if(essayHistory == null)
                {
                    return NotFound();
                }

                return Ok(essayHistory);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get essay info
        /// </summary>
        /// <param name="essayId"></param>
        /// <returns></returns>
        [HttpGet("{essayId}")]
        public async Task<ActionResult> GetEssayByIdAsync([FromRoute] string essayId)
        {
            var essay = await _essayServices.GetEssayByIdAsync(essayId);

            if(essay == null)
            {
                return NotFound();
            }
            return Ok(essay);
        }

        /// <summary>
        /// Create new essay
        /// </summary>
        /// <param name="essayRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CreateEssayAsync([FromBody]CreateEssayRequest essayRequest)
        {
            var essay = new Essay
            {
                userId = HttpContext.GetUserId(),
                Topic = essayRequest.Topic,
                Text = essayRequest.Text,
                Date = DateTime.Now,
                theLastFixingTime = DateTime.Now,
                isPublish = true
            };
            try
            {
                await _essayServices.CreateEssayAsync(essay);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

                string location = baseUrl + $"/api/essay/{essay.Id}";


                return Created(location, essay);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit essay
        /// </summary>
        /// <param name="essayId"></param>
        /// <param name="updateEssay"></param>
        /// <returns></returns>
        [HttpPut("{essayId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditEssayAsync([FromRoute]string essayId,[FromBody]UpdateEssayRequest updateEssay)
        {

            var userOwnEssay = await _essayServices.UserOwnEssayAsync(essayId, HttpContext.GetUserId());

            if (!userOwnEssay)
            {
                return BadRequest( new { error = "You do not own this essay" });
            }

            

            var essay = new Essay
            {
                Id = essayId,
                Text = updateEssay.Text,
                Date = updateEssay.Date,
                Topic = updateEssay.Topic,
                userId = HttpContext.GetUserId(),
            };

            var updated = await _essayServices.EditEssayAsync(essay);

            if (updated)
            {
                if(await _historyServices.Create(new History
                {
                    essayId = essayId,
                    userId = HttpContext.GetUserId(),
                    oldEssay = updateEssay.oldText,
                    newEssay = updateEssay.Text,
                    DateTime = DateTime.Now
                }))
                return Ok(essay);
            }

            // edi
            return NotFound();
        }

        /// <summary>
        /// Delete essay
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteEssayAsync([FromRoute]string id)
        {
            var deleted = await _essayServices.DeleteEssayByIdAsync(id);

            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
