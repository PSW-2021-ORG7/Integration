using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class TemporaryMedicineDTO
    {
        public string Name { get; set; }
        public int DosageInMilligrams { get; set; }
        public string Manufacturer { get; set; }
    }
}
