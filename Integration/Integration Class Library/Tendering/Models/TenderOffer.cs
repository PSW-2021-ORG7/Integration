using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integration_Class_Library.Tendering.Models
{
    [Table("TenderOffers")]
    public class TenderOffer
    {
        [Key]
        public int IdTenderOffer { get; private set; }
        public int IdTender { get; private set; }
        public int IdPharmacy { get; private set; }
        public double PriceForAllAvailable { get; private set; }
        public double PriceForAllRequired { get; private set; }
        public int TotalNumberMissingMedicine { get; private set; }
        public ICollection<TenderOfferItem> TenderOfferItems { get; private set; }

        public TenderOffer(double priceForAllAvailable, double priceForAllRequired, int totalNumberMissingMedicine)
        {
            PriceForAllAvailable = priceForAllAvailable;
            PriceForAllRequired = priceForAllRequired;
            TotalNumberMissingMedicine = totalNumberMissingMedicine;
            TenderOfferItems = new List<TenderOfferItem>();
        }

        public void addItem(TenderOfferItem item)
        {
            this.TenderOfferItems.Add(item);
        }

        public void removeItem(TenderOfferItem item)
        {
            this.TenderOfferItems.Remove(item);
        }

        public void setPharmacyId(int id)
        {
            this.IdPharmacy = id;
        }

        public void setTenderId(int id)
        {
            this.IdTender = id;
        }

    }
}
