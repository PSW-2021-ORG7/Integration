using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private PrescriptionService prescriptionService;
        private readonly IConfiguration _configuration;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IConfiguration configuration)
        {
            this._configuration = configuration;
            prescriptionService = new PrescriptionService(prescriptionRepository);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("It works!");
        }

        [HttpGet]
        public IActionResult GetPharmacies()
        {
            return Ok(prescriptionService.GetAllPrescriptions());
        }

        [HttpGet("{id}")]
        public IActionResult GetPrescriptionById(int id)
        {
            return Ok(prescriptionService.GetPrescriptionById(id));
        }
    }
}
