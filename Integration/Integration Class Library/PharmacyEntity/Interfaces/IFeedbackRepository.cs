using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> CreateFeedback(Feedback feedback);
        Task<List<Feedback>> GetAllFeedback();
        Task<Feedback> GetFeedbackById(String id);
        Task<int> PutFeedback(String id, Feedback feedback);
        Task<ActionResult<Feedback>> DeleteFeedback(String id);
    }
}
