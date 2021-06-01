using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportingIELTSWriting.Infrastructure;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Models.RequestModel;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Member")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EssayController : ControllerBase
    {
        private readonly IEssayServices _essayServices;
        private readonly IHistoryServices _historyServices;
        private readonly ILogger<EssayController> _logger;
        public EssayController(IEssayServices es, IHistoryServices historyServices, ILogger<EssayController> logger)
        {
            _essayServices = es;
            _historyServices = historyServices;
            _logger = logger;
        }

        [HttpGet("essays")]
        public IActionResult GetEssayPopular(int page = 1)
        {



            return null;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEssays()
        {
            return Ok(await _essayServices.GetEssaysAsync(HttpContext.GetUserId()));
        }

        [HttpGet("history/{essayId}")]
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

        

        [HttpPost]
        public async Task<ActionResult> CreateEssayAsync([FromBody]CreateEssayRequest essayRequest)
        {
            var essay = new Essay
            {
                userId = HttpContext.GetUserId(),
                Topic = essayRequest.Topic,
                Text = essayRequest.Text,
                Date = DateTime.Now
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

        [HttpPut("{essayId}")]
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
                    newEssay = updateEssay.Text
                }))
                return Ok(essay);
            }

            // edi
            return NotFound();
        }

        [HttpDelete("{id}")]
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
