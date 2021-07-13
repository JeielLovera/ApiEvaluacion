using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using ApiEvaluacion.DomainLayer.Entities;

namespace ApiEvaluacion.DataLayer.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
