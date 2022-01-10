using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Integration_Class_Library.Tendering
{
    [Table("Tenders")]
    public class Tender
    {
        CultureInfo provider = CultureInfo.InvariantCulture;

        [Key]
        public int Id { get; private set; }
        public string TenderKey { get; private set; } // Ne radi sa private set?
        public bool IsActive { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int IdWinnerPharmacy { get; private set; }

        public Tender(bool isActive, string startDate, string endDate, int idWinnerPharmacy)
        {
            TenderKey = TenderKey = Guid.NewGuid().ToString(); ;
            IsActive = isActive;
            IdWinnerPharmacy = idWinnerPharmacy;

            try
            {
                StartDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", provider);
                EndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", provider);
            }
            catch(Exception e)
            {

            }
         
        }

        public Tender() { }

        public void setActivity(bool isActive)
        {
            IsActive = isActive;
        }

        public void setWinner(int id)
        {
            IdWinnerPharmacy = id;
        }

    }
}
