using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityResponse>> GetAll()
        {
            var activities = await _unitOfWork.activityRepository.GetAll();
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<int> Save(ActivityRequest activityRequest)
        {
            var activity = _mapper.Map<Activity>(activityRequest);
            var activitySaved = await _unitOfWork.activityRepository.Save(activity);
            return activity.Id;
        }
    }
}
