using Integration_Class_Library.DAL;
using Integration_Class_Library.Tendering.Interfaces;
using Integration_Class_Library.Tendering.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.Tendering.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly IntegrationDbContext _context;
        public TenderRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public List<Tender> GetAllTenders()
        {
            return _context.Tenders.ToList();
        }

        public List<Tender> GetActiveTenders()
        {
            return _context.Tenders.Where(m => m.IsActive == true && m.EndDate > DateTime.Now).ToList();
        }

        public Tender GetTenderById(int id)
        {
            return _context.Tenders.SingleOrDefault(m => m.Id == id);
        }

        public Tender GetTenderByKey(string key)
        {
            return _context.Tenders.SingleOrDefault(m => m.TenderKey.Equals(key));
        }

        public bool CreateTender(Tender tender)
        {

            try
            {
                _context.Add(tender);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }          

        }

        public TenderOffer GetTenderOfferByTenderId(int tenderId)
        {
            return _context.TenderOffers.SingleOrDefault(m => m.IdTender == tenderId);
        }

        public List<TenderOffer> GetAllTenderOffersByTenderId(int id)
        {
            return _context.TenderOffers.Where(m => m.IdTender == id).ToList();
        }

        public void CreateTenderOffer(TenderOffer offer)
        {
            _context.Add(offer);
            _context.SaveChanges();
            
        }

        public bool SetWinner(Tender tender)
        {
            try
            {
                UpdateTenderFields(tender);
                return true;
            } catch (Exception e)
            {
                return false;
            }
            
        }

        public bool CloseTender(Tender tender)
        {
            UpdateTenderFields(tender);
            return true;
        }

        private void UpdateTenderFields(Tender tender)
        {
            _context.Tenders.Attach(tender);
            _context.Entry(tender).Property(x => x.IdWinnerPharmacy).IsModified = true;
            _context.Entry(tender).Property(x => x.IsActive).IsModified = true;
            _context.SaveChanges();
        }
    }
}
