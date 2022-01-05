using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.FeedbackCreatedEvent
{
    public class FeedbackCreatedEventService : ILogEventService<FeedbackCreatedEventParams>
    {
        private readonly IFeedbackCreatedEventRepository _feedbackCreatedEventRepository;

        public FeedbackCreatedEventService(IFeedbackCreatedEventRepository feedbackCreatedEventRepository)
        {
            _feedbackCreatedEventRepository = feedbackCreatedEventRepository;
        }

        public void LogEvent(FeedbackCreatedEventParams eventParams)
        {
            var buildingSelectionEvent = new FeedbackCreated
            { TimeStamp = DateTime.Now ,
              FeedbackId = eventParams.FeedbackId
            };

            _feedbackCreatedEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<FeedbackCreated> GetAll()
        {
            return _feedbackCreatedEventRepository.GetAll();
        }
    }
}
