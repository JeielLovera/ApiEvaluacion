using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEvaluacion.ApiLayer.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("query-roles")]
        public async Task<ActionResult<List<EmployeeResponse>>> QueryByRoles([FromBody] QueryRoles queryRoles)
        {
            return Ok(await _employeeService.GetAllByRoles(queryRoles));
        }
    }
}
