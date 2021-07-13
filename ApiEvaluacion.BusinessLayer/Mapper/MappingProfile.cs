using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using AutoMapper;

namespace ApiEvaluacion.BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<JobSectorRequest, JobSector>();
            CreateMap<JobSector, JobSectorResponse>();
            CreateMap<ActivityRequest, Activity>();
            CreateMap<Activity, ActivityResponse>();
            CreateMap<QuestionnaireRequest, Questionnaire>();
        }
    }
}
