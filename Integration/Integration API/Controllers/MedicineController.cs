using Microsoft.Extensions.Configuration;
using backend.Repositories.Interfaces;
using Integration_API.DTO;
using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using Integration_Class_Library.TenderingEntity.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private MedicineService _medicineService;
        private MedicineInventoryService _medicineInventoryService;
        private MedicineCombinationService _medicineCombinationService;

        public MedicineController(IConfiguration configuration, IMapper mapper, IMedicineRepository medicineRepository,
            IMedicineInventoryRepository medicineInventoryRepository, IMedicineCombinationRepository medicineCombinationRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _medicineService = new MedicineService(medicineRepository, medicineInventoryRepository);
            _medicineInventoryService = new MedicineInventoryService(medicineInventoryRepository);
            _medicineCombinationService = new MedicineCombinationService(medicineCombinationRepository);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("It works!");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicineService.GetAll());
        }


        [HttpPost]
        public IActionResult CreateMedicine([FromBody] NewMedicineDTO medicineDTO)
        {
            Medicine medicine = _mapper.Map<Medicine>(medicineDTO);

            if (_medicineService.Save(medicine))
            {
                _medicineInventoryService.Save(new MedicineInventory(medicine.Id));
                foreach (int m in medicineDTO.MedicinesToCombineWith)
                {
                    _medicineCombinationService.Save(medicine.Id, m);
                }
                return Ok("Succesfully added medicine");
            }
            return BadRequest("Medicine with that name and dosage already exists");
        }


        [HttpGet("find/{name}/{dose}")]
        public ActionResult<Medicine> GetMedicineByNameAndDose(string name, int dose)
        {
            Medicine medicine = _medicineService.GetByNameAndDose(name, dose);

            if (medicine == null) return NotFound("This medicine doesn't exist.");
            return medicine;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePharmacy(int id)
        {
            if (_medicineService.DeleteMedicine(id)) return Ok("Successfully deleted");
            return NotFound("This medicine doesn't exist.");
        }

        // INVENTORY

        [HttpPost]
        [Route("/inventory/check")]
        public IActionResult ProcessOrder([FromBody] Medicine medicine, int quantity)
        {
            if (_medicineService.MedicineExists(medicine))
            {
                Medicine foundMedicine = _medicineService.GetByNameAndDose(medicine.Name, medicine.DosageInMilligrams);
                return Ok(_medicineInventoryService.Update(new MedicineInventory(foundMedicine.Id, quantity)));
            }
            else
            {
                if (_medicineService.Save(medicine))
                    return Ok(_medicineInventoryService.Update(new MedicineInventory(medicine.Id, quantity)));

                return Ok(false);
            }           
        }

        [HttpGet]
        [Route("/inventory")]
        public IActionResult GetInventory()
        {
            return Ok(_medicineInventoryService.GetAll());
        }

        [HttpPut]
        [Route("/inventory/{id}")]
        public IActionResult UpdateInventory([FromBody] MedicineInventory medicineInventory)
        {
            return Ok(_medicineInventoryService.Update(medicineInventory));
        }
    }
}
