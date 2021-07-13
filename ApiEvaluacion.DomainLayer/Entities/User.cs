using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleUser { get; set; }  
        
        public Employee Employee { get; set; }
    }
}
