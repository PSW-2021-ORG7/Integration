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
        private TenderingService _tenderingService;

        public TenderingController()
        {
            _tenderingService = new TenderingService();
        }

        [HttpGet("test")]
        public IActionResult GetTest()
        {
            return Ok("It works");
        }

        [HttpPost("sendRequest")]
        public IActionResult SendTenderRequest([FromBody] TenderRequest tenderRequest)
        {
            _tenderingService.sendRequestToPharmacy(tenderRequest);
            return Ok();
        }

    }
}
