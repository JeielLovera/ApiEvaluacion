using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get;set; }
        public string Password { get; set; }
        public string NamesUser { get; set; }
        public string RoleUser { get; set; }
    }
}
