using System;
using Microsoft.AspNetCore.Mvc;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_API.Filters;
using Integration_Class_Library.PharmacyEntity.Services;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Integration_API.DTO;
using Integration_Class_Library.Events.PharmacyRegisteredEvent;
using HospitalClassLibrary.Events.LogEvent;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class PharmacyController : Controller
    {
        private PharmacyService pharmacyService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PharmacyController(IPharmacyRepository pharmacyRepository, IConfiguration configuration, IMapper mapper,
            ILogEventService<PharmacyRegisteredEventParams> logEventService)
        {
            this._configuration = configuration;
            pharmacyService = new PharmacyService(pharmacyRepository, logEventService);
            _mapper = mapper;
        }

          // GET: api/pharmacies/id
        [HttpGet("{id}")]
        public IActionResult GetPharmacyById(int id)
        {
            return Ok(pharmacyService.GetPharmacyById(id));
        }

        // GET: Pharmacies/
        public IActionResult GetPharmacies()
        {
            return Ok(pharmacyService.GetPharmacies());
        }

        // POST: api/pharmacies
        [HttpPost]
        public IActionResult PostPharmacy([FromBody] NewPharmacyDTO pharmacyDTO)
        {
            Pharmacy pharmacy = _mapper.Map<Pharmacy>(pharmacyDTO);
            Pharmacy created = pharmacyService.PostPharmacy(pharmacy);

            if (created != null) return Ok(true);
            else return BadRequest();
        }

        // PUT: api/pharmacies/id
        [HttpPut("{id}")]
        public IActionResult PutPharmacy(int id, [FromBody] Pharmacy pharmacy)
        {
           return Ok(pharmacyService.PutPharmacy(id, pharmacy));
        }

        // DELETE: api/pharmacies/id
        [HttpDelete("{id}")]
        public IActionResult DeletePharmacy(int id)
        {
            return Ok(pharmacyService.DeletePharmacy(id));
        }

        // GET: api/pharmacy/downloadSpec/fileName
        [HttpGet("downloadSpec/{fileName}")]
        public IActionResult DownloadMedicationSpecification(String fileName)
        {
            if (pharmacyService.DownloadMedicationSpecification(fileName))
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
