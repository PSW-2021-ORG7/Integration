using Integration_API.DTO;
using Integration_API.RabbitMQServices;
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

        [HttpGet("getOffers/{id}")]
        public IActionResult GetAllTenderOffersByTenderId(int id)
        {
            return Ok(_tenderingService.GetAllTenderOffersByTenderId(id));
        }

        [HttpPost("addTender")]
        public IActionResult CreateTender([FromBody] TenderDTO tenderDTO)
        {
            Tender tender = new Tender(tenderDTO.IsActive, tenderDTO.StartDate, tenderDTO.EndDate, tenderDTO.IdWinnerPharmacy);
            if (_tenderingService.CreateTender(tender)) return Ok(tender);
            else return BadRequest();
        }

        [HttpPost("addOffer")]
        public IActionResult AddTenderOffer([FromBody] TenderOfferDTO tenderOfferDTO)
        {
            TenderOffer offer = new TenderConsumerService().CreateOffer(tenderOfferDTO);
            _tenderingService.AddTenderOffer(offer);
            return Ok();
        }

        [HttpPost("sendRequest")]
        public IActionResult SendTenderRequest([FromBody] TenderRequest tenderRequest)
        {
            _tenderingService.sendRequestToPharmacy(tenderRequest);
            return Ok();
        }

    }
}
