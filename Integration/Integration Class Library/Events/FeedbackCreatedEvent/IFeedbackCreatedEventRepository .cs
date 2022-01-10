using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.FeedbackCreatedEvent
{
    public interface IFeedbackCreatedEventRepository : IEventRepository<FeedbackCreated>
    {
        List<FeedbackCreated> GetAll();
    }
}
