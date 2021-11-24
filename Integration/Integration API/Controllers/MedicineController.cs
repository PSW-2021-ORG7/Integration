using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.Controllers
{
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
