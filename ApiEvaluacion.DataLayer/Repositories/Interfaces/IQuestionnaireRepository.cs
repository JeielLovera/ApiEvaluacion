using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEvaluacion.DataLayer.Repositories.Interfaces
{
    public interface IQuestionnaireRepository : IRepository<Questionnaire>
    {
        Task<IEnumerable<QuestionnaireResponse>> GetAllDetail();

        Task<QuestionnaireResponse> GetDetailById(int id);
    }
}
