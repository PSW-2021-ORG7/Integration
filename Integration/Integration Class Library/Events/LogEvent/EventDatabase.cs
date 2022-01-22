using Integration_Class_Library.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalClassLibrary.Events.LogEvent
{
    public abstract class EventDatabase<T> : IEventRepository<T> where T : Event
    {
        protected readonly IntegrationDbContext DbContext;

        protected EventDatabase(IntegrationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract void LogEvent(T @event);
    }
}
