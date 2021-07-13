using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Implementation
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionnaireService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionnaireResponse>> GetAllDetail()
        {
            return await _unitOfWork.questionnaireRepository.GetAllDetail();
        }

        public async Task<QuestionnaireResponse> GetDetailById(int id)
        {
            return await _unitOfWork.questionnaireRepository.GetDetailById(id);
        }

        public async Task<int> Save(QuestionnaireRequest questionnaireRequest)
        {
            var user = (await _unitOfWork.userRepository.Get(filter: x => x.Email == questionnaireRequest.EmailUser)).FirstOrDefault();

            if (user == null) return 0;

            var questionnaire = _mapper.Map<Questionnaire>(questionnaireRequest);
            questionnaire.UserId = user.Id;
            questionnaire.DateQuestionnaire = DateTime.UtcNow;
            var questionnaireSaved = await _unitOfWork.questionnaireRepository.Save(questionnaire);
            return questionnaireSaved.Id;
        }
    }
}
