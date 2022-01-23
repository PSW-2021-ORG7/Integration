using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Class_Library.Events.FeedbackCreatedEvent
{
    public class FeedbackCreatedEventDatabase : EventDatabase<FeedbackCreated>, IFeedbackCreatedEventRepository
    {
        public FeedbackCreatedEventDatabase(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(FeedbackCreated @event)
        {
            DbContext.FeedbackCreated.Add(@event);
            DbContext.SaveChanges();
        }

        public List<FeedbackCreated> GetAll()
        {
            foreach (FeedbackCreated building in DbContext.FeedbackCreated.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.FeedbackCreated.ToList();
        }
    }
}
