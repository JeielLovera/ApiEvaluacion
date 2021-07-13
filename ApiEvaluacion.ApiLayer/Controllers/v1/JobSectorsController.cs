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
    public class JobSectorsController : ControllerBase
    {
        private readonly IJobSectorService _jobSectorService;

        public JobSectorsController(IJobSectorService jobSectorService)
        {
            _jobSectorService = jobSectorService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<JobSectorResponse>>> GetAll()
        {
            return Ok(await _jobSectorService.GetAll());
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
        public async Task<ActionResult<int>> Save([FromBody] JobSectorRequest jobSectorRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _jobSectorService.Save(jobSectorRequest));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
