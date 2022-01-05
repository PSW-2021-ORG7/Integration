using HospitalClassLibrary.Events.LogEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Events.PharmacyRegisteredEvent
{
    public class PharmacyRegisteredEventService : ILogEventService<PharmacyRegisteredEventParams>
    {
        private readonly IPharmacyRegisteredEventRepository _pharmacyRegisteredEventRepository;

        public PharmacyRegisteredEventService(IPharmacyRegisteredEventRepository pharmacyRegisteredEventRepository)
        {
            _pharmacyRegisteredEventRepository = pharmacyRegisteredEventRepository;
        }

        public void LogEvent(PharmacyRegisteredEventParams eventParams)
        {
            var buildingSelectionEvent = new PharmacyRegistered
            { TimeStamp = DateTime.Now,
              IdPharmacy = eventParams.IdPharmacy
            };

            _pharmacyRegisteredEventRepository.LogEvent(buildingSelectionEvent);
        }

        public List<PharmacyRegistered> GetAll()
        {
            return _pharmacyRegisteredEventRepository.GetAll();
        }
    }
}
