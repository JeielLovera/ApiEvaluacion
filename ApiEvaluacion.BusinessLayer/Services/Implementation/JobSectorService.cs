using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Implementation
{
    public class JobSectorService : IJobSectorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobSectorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobSectorResponse>> GetAll()
        {
            var jobs = await _unitOfWork.jobSectorRepository.GetAll();
            return _mapper.Map<IEnumerable<JobSectorResponse>>(jobs);
        }

        public async Task<int> Save(JobSectorRequest jobSectorRequest)
        {
            var job = _mapper.Map<JobSector>(jobSectorRequest);
            var jobSaved = await _unitOfWork.jobSectorRepository.Save(job);
            return jobSaved.Id;
        }
    }
}
