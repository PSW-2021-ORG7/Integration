using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDbContext _context;
        public FeedbackRepository(FeedbackDbContext context)
        {
            _context = context;
        }
        public async Task<Feedback> CreateFeedback(Feedback feedback)
        {
            _context.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<ActionResult<Feedback>> DeleteFeedback(string id)
        {
            var feedback = await _context.Feedback.FindAsync(id);
            if (feedback == null)
            {
                //return NotFound(); ?
                return null;
            }

            _context.Feedback.Remove(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        public async Task<List<Feedback>> GetAllFeedback()
        {
            return await _context.Feedback.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(string id)
        {
            return await _context.Feedback.FindAsync(id);
        }

        public async Task<List<Feedback>> GetFeedbackByPharmacyId(string idPharmacy)
        { 
            return await _context.Feedback.Where(x => x.IdPharmacy.Equals(idPharmacy)).ToListAsync();
        }

        public async Task<int> PutFeedback(string id, Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
                {
                    return -1;
                }

                throw;
            }

            return 0;
        }

        private bool FeedbackExists(String id)
        {
            return _context.Feedback.Any(e => e.IdPharmacy == id);
        }

    }
}
