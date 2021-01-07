using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportingIELTSWriting.Infrastructure;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Models.RequestModel;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EssayController : ControllerBase
    {
        private readonly IEssayServices _essayServices;
        private readonly IHistoryServices _historyServices;
        public EssayController(IEssayServices es, IHistoryServices historyServices)
        {
            _essayServices = es;
            _historyServices = historyServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _essayServices.GetEssaysAsync(HttpContext.GetUserId()));
        }

        [HttpGet("history/{essayId}")]
        public async Task<IActionResult> GetHistory([FromRoute] string essayId)
        {
            var essayHistory = await _essayServices.GetHistoriesByEssayIdAsync(essayId);

            if(essayHistory == null)
            {
                return NotFound();
            }

            return Ok(essayHistory);
        }

        [HttpGet("{essayId}")]
        public async Task<ActionResult> Get([FromRoute] string essayId)
        {
            var essay = await _essayServices.GetEssayByIdAsync(essayId);

            if(essay == null)
            {
                return NotFound();
            }

            return Ok(essay);
        }


        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody]CreateEssayRequest essayRequest)
        {
            var essay = new Essay
            {
                userId = HttpContext.GetUserId(),
                Topic = essayRequest.Topic,
                Text = essayRequest.Text,
                Date = DateTime.Now
            };

            await _essayServices.CreateEssayAsync(essay);

            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string location = baseUrl + $"/api/essay/{essay.Id}";


            return Created(location, essay);
        }

        [HttpPut("{essayId}")]
        public async Task<IActionResult> EditAsync([FromRoute]string essayId,[FromBody]UpdateEssayRequest updateEssay)
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
                    essayId = essayId, userId = HttpContext.GetUserId(), oldEssay = updateEssay.oldText, newEssay = updateEssay.Text
                }))
                return Ok(essay);
            }

            // edi
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
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
