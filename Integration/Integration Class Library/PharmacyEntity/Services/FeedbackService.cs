using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.Events.FeedbackCreatedEvent;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using System.Collections.Generic;

namespace Integration_Class_Library.PharmacyEntity.Services
{
    public class FeedbackService
    {
        IFeedbackRepository feedbackRepository;
        private readonly ILogEventService<FeedbackCreatedEventParams> _logEventService;

        public FeedbackService(IFeedbackRepository feedbackRepository, ILogEventService<FeedbackCreatedEventParams> logEventService)
        {
            this.feedbackRepository = feedbackRepository;
            _logEventService = logEventService;

        }
        public List<Feedback> GetAllFeedback()
        {
            return feedbackRepository.GetAllFeedback();
        }
        public Feedback GetFeedbackById(int id)
        {
            return feedbackRepository.GetFeedbackById(id);
        }

        public List<Feedback> GetAllFeedbackByPharmacyId(int id)
        {
            return feedbackRepository.GetAllFeedbackByPharmacyId(id);
        }

        public List<Feedback> GetPharmacies()
        {
            return feedbackRepository.GetAllFeedback();
        }

        public Feedback PostFeedback(Feedback feedback)
        {
            Feedback created = feedbackRepository.CreateFeedback(feedback);
            _logEventService.LogEvent(new FeedbackCreatedEventParams(created.IdFeedback));
            return created;
        }

        public bool PutFeedback(int id, Feedback feedback)
        {
            return feedbackRepository.PutFeedback(id, feedback);
        }

        public bool DeleteFeedback(int id)
        {
            return feedbackRepository.DeleteFeedback(id);
        }
    }
}
