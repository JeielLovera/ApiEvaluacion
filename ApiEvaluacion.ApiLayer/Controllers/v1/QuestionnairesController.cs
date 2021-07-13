using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEvaluacion.ApiLayer.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuestionnairesController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnairesController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
        public async Task<ActionResult<List<QuestionnaireResponse>>> GetAll()
        {
            return Ok(await _questionnaireService.GetAllDetail());
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
        public async Task<ActionResult<QuestionnaireResponse>> GetById(int id)
        {
            return Ok(await _questionnaireService.GetDetailById(id));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "EMPLEADO")]        
        public async Task<ActionResult<int>> Save([FromBody] QuestionnaireRequest questionnaireRequest)
        {
            if (ModelState.IsValid)
            {
                var questionnaireId = await _questionnaireService.Save(questionnaireRequest);
                if (questionnaireId > 0)
                {
                    return Ok(questionnaireId);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
