using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Interfaces
{
    public interface IJobSectorService
    {
        Task<IEnumerable<JobSectorResponse>> GetAll();

        Task<int> Save(JobSectorRequest jobSectorRequest);
    }
}
