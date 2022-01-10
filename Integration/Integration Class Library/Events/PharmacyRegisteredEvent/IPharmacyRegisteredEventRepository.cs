using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.PharmacyRegisteredEvent
{
    public interface IPharmacyRegisteredEventRepository : IEventRepository<PharmacyRegistered>
    {
        List<PharmacyRegistered> GetAll();
    }
}
