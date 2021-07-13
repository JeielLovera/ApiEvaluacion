using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DomainLayer.Models.Request;
using ApiEvaluacion.DomainLayer.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiEvaluacion.ApiLayer.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<UserToken>> SignUpUser([FromBody] UserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.Save(userRequest);
                if (userId > 0)
                {
                    return BuildToken(userRequest.Email, userRequest.RoleUser, userRequest.Employee.NamesEmployee);
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

        [HttpPost("sign-in")]
        public async Task<ActionResult<UserToken>> SignIngUser([FromBody] UserLogin userLogin)
        {
            var user = await _userService.GetByCredentials(userLogin);

            if (user != null)
            {
                return BuildToken(user.Email, user.RoleUser, user.NamesUser);
            }
            else
            {
                return BadRequest();
            }
        }

        private UserToken BuildToken(string userEmail, string userRole, string userNames)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userRole),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new UserToken
            {
                EmailUser = userEmail,
                NamesUser = userNames,
                RoleUser = userRole,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };

        }
    }
}
