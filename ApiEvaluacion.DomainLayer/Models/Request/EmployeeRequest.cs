using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class EmployeeRequest
    {
        [Required(ErrorMessage = "Los nombres no pueden ser nulo")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden contener más de 100 caracteres")]
        public string NamesEmployee { get; set; }

        [Required(ErrorMessage = "El rol no puede ser nulo")]
        [MaxLength(20, ErrorMessage = "El rol no puede contener más de 20 caracteres")]
        public string RoleEmployee { get; set; }        
    }
}
