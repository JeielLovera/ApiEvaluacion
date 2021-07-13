using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Entities;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using ApiEvaluacion.DomainLayer.Utils;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEvaluacion.BusinessLayer.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllByRoles(QueryRoles queryRoles)
        {
            var employees = await _unitOfWork.employeeRepository.Get(filter: x => queryRoles.Roles.Contains(x.RoleEmployee));
            return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);
        }
    }
}
