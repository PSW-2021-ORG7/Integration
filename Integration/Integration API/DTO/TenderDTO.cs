using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTO
{
    public class TenderDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int IdWinnerPharmacy { get; set; }
    }
}
