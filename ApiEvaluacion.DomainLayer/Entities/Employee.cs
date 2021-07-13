using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string NamesEmployee { get; set; }
        public string RoleEmployee { get; set; }
        public int UserId { get; set; }
    }
}
