using Integration_Class_Library.Tendering.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Interfaces
{
    public interface ITenderRepository
    {
        List<Tender> GetAllTenders();
        List<Tender> GetActiveTenders();
        Tender GetTenderById(int id);
        bool CreateTender(Tender tender);
        TenderOffer GetTenderOfferByTenderId(int id);
        bool CreateTenderOffer(TenderOffer offer);
    }
}
