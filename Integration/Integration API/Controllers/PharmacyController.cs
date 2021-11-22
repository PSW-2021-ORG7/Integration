using System;
using Microsoft.AspNetCore.Mvc;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_API.Filters;
using Integration_Class_Library.PharmacyEntity.Services;
using Microsoft.Extensions.Configuration;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class PharmacyController : Controller
    {
        private PharmacyService pharmacyService;
        private readonly IConfiguration _configuration;

        public PharmacyController(IPharmacyRepository pharmacyRepository, IConfiguration configuration)
        {
            this._configuration = configuration;
            pharmacyService = new PharmacyService(pharmacyRepository);
        }

          // GET: api/pharmacies/id
        [HttpGet("{id}")]
        public IActionResult GetPharmacyById(String id)
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
        public IActionResult PostPharmacy([FromBody] Pharmacy pharmacy)
        {
            return Ok(pharmacyService.PostPharmacy(pharmacy));
        }

        // PUT: api/pharmacies/id
        [HttpPut("{id}")]
        public IActionResult PutPharmacy(String id, Pharmacy pharmacy)
        {
           return Ok(pharmacyService.PutPharmacy(id, pharmacy));
        }

        // DELETE: api/pharmacies/id
        [HttpDelete("{id}")]
        public IActionResult DeletePharmacy(String id)
        {
            return Ok(pharmacyService.DeletePharmacy(id));
        }

        // GET: api/pharmacy/downloadSpec/fileName
        [HttpGet("downloadSpec/{fileName}")]
        public IActionResult DownloadMedicationSpecification(String fileName)
        {
            return Ok(pharmacyService.DownloadMedicationSpecification(fileName));
        }

    }
}
