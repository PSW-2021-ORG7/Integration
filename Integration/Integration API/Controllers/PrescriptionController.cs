using backend.Repositories.Interfaces;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Services;
using Integration_Class_Library.TenderingEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.Models;
using Integration_Class_Library.TenderingEntity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        private PrescriptionService _prescriptionService;
        private MedicineService _medicineService;
        private readonly IConfiguration _configuration;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMedicineInventoryRepository medicineInventoryRepository, IMedicineRepository medicineRepository, IConfiguration configuration)
        {
            this._medicineService = new MedicineService(medicineRepository, medicineInventoryRepository);
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
            Prescription response = _prescriptionService.GetPrescriptionById(id);
            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("SFTP")]
        public IActionResult SendPrescriptionSFTP([FromBody] Prescription prescription)
        {
            try {
   
                string filename = prescription.PatientJMBG.Replace(" ", "") + ".pdf";
                PdfDocument document = createDocument(prescription);

                document.Save("Output/" + filename);
                _prescriptionService.SendPrescriptionSFTP(filename);
                return Ok(JsonConvert.SerializeObject(filename));
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private PdfDocument createDocument(Prescription prescription)
        {          
            Medicine medicine = _medicineService.GetByID(prescription.MedicineId);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            document.Info.Title = prescription.PatientJMBG;
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
            XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Bold);

            gfx.DrawString("Prescription", fontTitle, XBrushes.Goldenrod, 5.0, 25.0);
            gfx.DrawString("Patient's name ", font, XBrushes.Goldenrod, 5.0, 40.0);
            gfx.DrawString(prescription.Patient, font, XBrushes.Black,
                   new XRect(200.0, 35.0, 0.0, 0.0),
                   XStringFormats.Center);

            gfx.DrawString("JMBG ", font, XBrushes.Goldenrod, 5.0, 60.0);
            gfx.DrawString(prescription.PatientJMBG, font, XBrushes.Black,
                    new XRect(200.0, 55.0, 0.0, 0.0),
                    XStringFormats.Center);

            gfx.DrawString("Duration in days ", font, XBrushes.Goldenrod, 5.0, 80.0);
            gfx.DrawString(prescription.DurationInDays.ToString(), font, XBrushes.Black,
                    new XRect(200.0, 75.0, 0.0, 0.0),
                    XStringFormats.Center);

            gfx.DrawString("Times per day ", font, XBrushes.Goldenrod, 5.0, 100.0);
            gfx.DrawString(prescription.TimesPerDay.ToString(), font, XBrushes.Black,
                    new XRect(200.0, 95.0, 0.0, 0.0),
                    XStringFormats.Center);

            gfx.DrawString("Description ", font, XBrushes.Goldenrod, 5.0, 120.0);
            gfx.DrawString(prescription.Description, font, XBrushes.Black,
                    new XRect(200.0, 115.0, 0.0, 0.0),
                    XStringFormats.Center);

            gfx.DrawString("Doctor's name ", font, XBrushes.Goldenrod, 5.0, 140.0);
            gfx.DrawString(prescription.Doctor, font, XBrushes.Black,
                    new XRect(200.0, 135.0, 0.0, 0.0),
                    XStringFormats.Center);

            gfx.DrawString("Medicine ", font, XBrushes.Goldenrod, 5.0, 160.0);
            gfx.DrawString(medicine.Name + medicine.DosageInMilligrams, font, XBrushes.Black,
                    new XRect(200.0, 155.0, 0.0, 0.0),
                    XStringFormats.Center);

            return document;
           
        }
    }
}
