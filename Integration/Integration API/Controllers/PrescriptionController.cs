using backend.Repositories.Interfaces;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Services;
using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private PrescriptionService _prescriptionService;
        private readonly IConfiguration _configuration;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, IConfiguration configuration)
        {
            this._configuration = configuration;
            _prescriptionService = new PrescriptionService(prescriptionRepository, medicineRepository);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("It works!");
        }

        [HttpGet]
        public IActionResult GetPrescriptions()
        {
            return Ok(_prescriptionService.GetAllPrescriptions());
        }

        [HttpGet("{id}")]
        public IActionResult GetPrescriptionById(int id)
        {
            return Ok(_prescriptionService.GetPrescriptionById(id));
        }

        [HttpPost("SFTP")]
        public IActionResult SendPrescriptionSFTP([FromBody] Prescription prescription)
        {          
            return Ok(JsonConvert.SerializeObject(_prescriptionService.SendPrescriptionSFTP(prescription)));
        }
    }
}
