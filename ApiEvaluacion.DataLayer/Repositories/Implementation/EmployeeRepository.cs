using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using ApiEvaluacion.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DataLayer.Repositories.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
