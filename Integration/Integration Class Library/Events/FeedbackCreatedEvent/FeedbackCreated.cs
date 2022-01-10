using HospitalClassLibrary.Events;
using Integration_Class_Library.PharmacyEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Integration_Class_Library.Events.FeedbackCreatedEvent
{
    [Table(nameof(FeedbackCreated), Schema = "Events")]
    public class FeedbackCreated : Event
    {
        public int FeedbackId { get; set; }
    }
}
