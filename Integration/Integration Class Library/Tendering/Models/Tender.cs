using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Integration_Class_Library.Tendering
{
    [Table("Tenders")]
    public class Tender
    {
        [Key]
        public int Id { get; private set; }
        public string TenderKey { get; set; } // Ne radi sa private set?
        public bool IsActive { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int IdWinnerPharmacy { get; private set; }

    }
}
