using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using ApiEvaluacion.DomainLayer.Entities;

namespace ApiEvaluacion.DataLayer.Repositories.Implementation
{
    public class JobSectorRepository : Repository<JobSector>, IJobSectorRepository
    {
        public JobSectorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
