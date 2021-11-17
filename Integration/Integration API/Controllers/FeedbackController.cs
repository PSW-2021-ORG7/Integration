using Integration_API.Filters;
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
        public FeedbackController(IFeedbackRepository feedback)
        {
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
        public async Task<ActionResult<Feedback>> GetFeedbackById(String id)
        {
            return Ok(await _feedback.GetFeedbackById(id));
        }

        //GET:
        [HttpGet("find/{idPharmacy}")]
        public async Task<ActionResult<Feedback>> GetFeedbackByPharmacyId(String idPharmacy)
        {
            return Ok(await _feedback.GetFeedbackByPharmacyId(idPharmacy));
        }

        //public async Task<List<Feedback>> GetFeedbackByPharmacyId(string idPharmacy)
        // POST: api/feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback([FromBody] Feedback feedback)
        {
            return Ok(await _feedback.CreateFeedback(feedback));
        }

        // PUT: api/feedback/id
        [HttpPut("{id}")]
        public async Task<int> PutFeedback(String id, Feedback feedback)
        {
            return (await _feedback.PutFeedback(id, feedback));
        }

        // DELETE: api/feedback/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(String id)
        {
            return (await _feedback.DeleteFeedback(id));
        }
    }
}
