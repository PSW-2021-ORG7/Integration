using HospitalClassLibrary.Events.LogEvent;
using Integration_API.Filters;
using Integration_Class_Library.Events.FeedbackCreatedEvent;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Integration_API.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    [ApiKeyAuth]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedback;
        private readonly ILogEventService<FeedbackCreatedEventParams> _logEventService;
        public FeedbackController(IFeedbackRepository feedback, ILogEventService<FeedbackCreatedEventParams> logEventService)
        {
            _logEventService = logEventService;
            _feedback = feedback;
        }

        // GET: api/feedback
        [HttpGet]
        public async Task<ActionResult<Feedback>> GetAllFeedback()
        {
            return Ok(await _feedback.GetAllFeedback());
        }

        // GET: api/feedback/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            return Ok(await _feedback.GetFeedbackById(id));
        }

        //GET:
        [HttpGet("find/{idPharmacy}")]
        public async Task<ActionResult<Feedback>> GetFeedbackByPharmacyId(int idPharmacy)
        {
            return Ok(await _feedback.GetFeedbackByPharmacyId(idPharmacy));
        }

        //public async Task<List<Feedback>> GetFeedbackByPharmacyId(string idPharmacy)
        // POST: api/feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback([FromBody] Feedback feedback)
        {
            Feedback updated = await _feedback.CreateFeedback(feedback);
            _logEventService.LogEvent(new FeedbackCreatedEventParams(updated.IdFeedback));
            return Ok(updated);
        }

        // PUT: api/feedback/id
        [HttpPut("{id}")]
        public async Task<int> PutFeedback(int id, Feedback feedback)
        {
            return (await _feedback.PutFeedback(id, feedback));
        }

        // DELETE: api/feedback/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            return (await _feedback.DeleteFeedback(id));
        }
    }
}
