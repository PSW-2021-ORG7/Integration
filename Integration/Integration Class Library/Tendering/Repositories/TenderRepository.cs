using Integration_Class_Library.DAL;
using Integration_Class_Library.Tendering.Interfaces;
using Integration_Class_Library.Tendering.Models;
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
            return _context.Tenders.Where(m => m.IsActive == false).ToList();
        }

        public Tender GetTenderById(int id)
        {
            return _context.Tenders.SingleOrDefault(m => m.Id == id);
        }

        public bool CreateTender(Tender tender)
        {

            try
            {
                _context.Add(tender);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }          

        }

        public TenderOffer GetTenderOfferByTenderId(int tenderId)
        {
            return _context.TenderOffers.SingleOrDefault(m => m.IdTender == tenderId);
        }

        public bool CreateTenderOffer(TenderOffer offer)
        {
            _context.Add(offer);
            _context.SaveChanges();
            return true;
        }
    }
}
