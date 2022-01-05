using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.PharmacyEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.FeedbackCreatedEvent
{
    public class FeedbackCreatedEventParams : EventParams
    {
        public FeedbackCreatedEventParams(int idFeedback)
        {
            this.FeedbackId = idFeedback;
        }

        public int FeedbackId { get; set; }
    }
}
