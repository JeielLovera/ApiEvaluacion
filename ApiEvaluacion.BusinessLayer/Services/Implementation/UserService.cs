using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using ApiEvaluacion.DomainLayer.Utils;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;        

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IDataProtectionProvider dataProtectionProvider, DataProtectorKeyStrings dataProtectorKeyStrings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;            
            _dataProtector = dataProtectionProvider.CreateProtector(dataProtectorKeyStrings.KeyPasswordProtector);
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _unitOfWork.userRepository.GetAll();
            foreach ( var user in users)
            {
                user.Password = _dataProtector.Unprotect(user.Password);
            }
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> GetByCredentials(UserLogin userLogin)
        {
            var user = (await _unitOfWork.userRepository
                .Get(filter: x => x.Email == userLogin.Email, includeProperties: "Employee"))
                .FirstOrDefault();

            if (user == null) return null;

            user.Password = _dataProtector.Unprotect(user.Password);

            if (user.Password != userLogin.Password) return null;

            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.NamesUser = user.Employee.NamesEmployee;

            return userResponse;          
        }

        public async Task<int> Save(UserRequest userRequest)
        {
            var users = await _unitOfWork.userRepository.Get(filter: x => x.Email.ToUpper() == userRequest.Email.ToUpper());
            
            if (users.Count() > 0) return 0;

            userRequest.Password = _dataProtector.Protect(userRequest.Password);
            var user = _mapper.Map<User>(userRequest);
            var userSaved = await _unitOfWork.userRepository.Save(user);
            return userSaved.Id;
        }
    }
}
