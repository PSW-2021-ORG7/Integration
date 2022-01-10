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
        Tender GetTenderByKey(string key);
        bool CreateTender(Tender tender);
        TenderOffer GetTenderOfferByTenderId(int id);
        void CreateTenderOffer(TenderOffer offer);
        List<TenderOffer> GetAllTenderOffersByTenderId(int id);
        bool SetWinner(Tender tender);
    }
}
