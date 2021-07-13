using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<IEnumerable<QuestionnaireResponse>> GetAllDetail();

        Task<QuestionnaireResponse> GetDetailById(int id);

        Task<int> Save(QuestionnaireRequest questionnaireRequest);

    }
}
