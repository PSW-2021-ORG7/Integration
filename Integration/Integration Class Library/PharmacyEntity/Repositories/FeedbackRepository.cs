using Integration_Class_Library.DAL;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Integration_Class_Library.PharmacyEntity.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IntegrationDbContext _context;
        public FeedbackRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public Feedback CreateFeedback(Feedback feedback)
        {
            _context.Add(feedback);
            _context.SaveChanges();
            return feedback;
        }

        public bool DeleteFeedback(int id)
        {
            var feedback = _context.Feedback.Find(id);
            if (feedback == null)
            {
                return false;
            }

            _context.Feedback.Remove(feedback);
            _context.SaveChanges();
            return true;
        }

        public List<Feedback> GetAllFeedback()
        {
            return _context.Feedback.ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _context.Feedback.Find(id);
        }

        public List<Feedback> GetAllFeedbackByPharmacyId(int idPharmacy)
        {
            return _context.Feedback.Where(x => x.IdPharmacy.Equals(idPharmacy)).ToList();
        }

        public bool PutFeedback(int id, Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                var entry = _context.Feedback.First(e => e.IdFeedback == feedback.IdFeedback);
                _context.Entry(entry).CurrentValues.SetValues(feedback);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
                {
                    return false;
                }

                throw;
            }

            return true;
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.IdPharmacy == id);
        }


    }
}
