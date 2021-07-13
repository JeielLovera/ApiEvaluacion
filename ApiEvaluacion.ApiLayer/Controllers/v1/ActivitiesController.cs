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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<ActivityResponse>>> GetAll()
        {
            return Ok(await _activityService.GetAll());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<int>> Save([FromBody] ActivityRequest activityRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _activityService.Save(activityRequest));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
