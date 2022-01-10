using HospitalClassLibrary.Events.LogEvent;
using Integration_Class_Library.PharmacyEntity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Class_Library.Events.PharmacyRegisteredEvent
{
    public class PharmacyRegisteredEventDatabase : EventDatabase<PharmacyRegistered>, IPharmacyRegisteredEventRepository
    {
        public PharmacyRegisteredEventDatabase(IntegrationDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(PharmacyRegistered @event)
        {
            DbContext.PharmacyRegistered.Add(@event);
            DbContext.SaveChanges();
        }

        public List<PharmacyRegistered> GetAll()
        {
            foreach (PharmacyRegistered building in DbContext.PharmacyRegistered.ToList())
                DbContext.Entry(building).Reload();
            return DbContext.PharmacyRegistered.ToList();
        }
    }
}
