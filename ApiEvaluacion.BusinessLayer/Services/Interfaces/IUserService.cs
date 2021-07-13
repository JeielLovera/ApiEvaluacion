using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAll();

        Task<UserResponse> GetByCredentials(UserLogin userLogin);

        Task<int> Save(UserRequest userRequest);
    }
}
