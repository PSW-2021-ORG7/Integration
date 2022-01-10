using Integration_Class_Library.Tendering;
using Integration_Class_Library.Tendering.Interfaces;
using Integration_Class_Library.Tendering.Models;
using Integration_Class_Library.Tendering.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Integration_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenderingController : Controller
    {
        private TenderService _tenderingService;

        public TenderingController(ITenderRepository tenderRepository)
        {
            _tenderingService = new TenderService(tenderRepository);
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("It works");
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            return Ok(_tenderingService.GetAllTenders());
        }

        [HttpPost("addTender")]
        public IActionResult CreateTender([FromBody] Tender tender)
        {
            if (_tenderingService.CreateTender(tender)) return Ok("Success!");
            else return BadRequest();
        }

        [HttpPost("sendRequest")]
        public IActionResult SendTenderRequest([FromBody] TenderRequest tenderRequest)
        {
            tenderRequest.TenderKey = Guid.NewGuid().ToString(); 
            _tenderingService.sendRequestToPharmacy(tenderRequest);
            return Ok();
        }

    }
}
