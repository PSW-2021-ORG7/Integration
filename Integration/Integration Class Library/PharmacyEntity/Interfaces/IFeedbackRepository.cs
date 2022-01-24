using Integration_Class_Library.PharmacyEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration_Class_Library.PharmacyEntity.Interfaces
{
    public interface IFeedbackRepository
    {
        Feedback CreateFeedback(Feedback feedback);
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        bool PutFeedback(int id, Feedback feedback);
        bool DeleteFeedback(int id);
        List<Feedback> GetAllFeedbackByPharmacyId(int idPharmacy);
    }
}
