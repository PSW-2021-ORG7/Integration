using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> CreateFeedback(Feedback feedback);
        Task<List<Feedback>> GetAllFeedback();
        Task<Feedback> GetFeedbackById(int id);
        Task<int> PutFeedback(int id, Feedback feedback);
        Task<ActionResult<Feedback>> DeleteFeedback(int id);
        Task<List<Feedback>> GetFeedbackByPharmacyId(int idPharmacy);
    }
}
