using AutoMapper;
using HospitalClassLibrary.Events.LogEvent;
using Integration_API.Filters;
using Integration_Class_Library.Events.FeedbackCreatedEvent;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using Integration_Class_Library.PharmacyEntity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Integration_API.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    [ApiKeyAuth]
    public class FeedbackController : Controller
    {
        private FeedbackService _feedbackService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public FeedbackController(IFeedbackRepository feedbackRepository, IConfiguration configuration, ILogEventService<FeedbackCreatedEventParams> logEventService, IMapper mapper)
        {
            this._configuration = configuration;
            _feedbackService = new FeedbackService(feedbackRepository, logEventService);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllFeedback()
        {
            return Ok(_feedbackService.GetAllFeedback());
        }

        [HttpGet("{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            return Ok(_feedbackService.GetFeedbackById(id));
        }

        [HttpGet("find/{idPharmacy}")]
        public IActionResult GetFeedbackByPharmacyId(int idPharmacy)
        {
            List<Feedback> feedback = _feedbackService.GetAllFeedbackByPharmacyId(idPharmacy);
            if (feedback.Count > 0) return Ok(feedback);
            else return NotFound();
        }

        [HttpPost]
        public IActionResult PostFeedback([FromBody] Feedback feedbackD)
        {
            Feedback feedback = _mapper.Map<Feedback>(feedbackD);
            return Ok(_feedbackService.PostFeedback(feedback));

        }

        [HttpPut("{id}")]
        public IActionResult PutFeedback(int id, Feedback feedback)
        {
            return Ok(_feedbackService.PutFeedback(id, feedback));

        }
    }
}
