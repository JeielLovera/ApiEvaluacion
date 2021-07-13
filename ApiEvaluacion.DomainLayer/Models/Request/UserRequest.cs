using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "El email no puede ser nulo")]
        [MaxLength(100, ErrorMessage = "El email no puede contener más de 100 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no puede ser nulo")]
        [MaxLength(20, ErrorMessage = "La contraseña no puede contener más de 20 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El rol no puede ser nulo")]
        [MaxLength(20, ErrorMessage = "El rol no puede contener más de 20 caracteres")]
        public string RoleUser { get; set; }

        public EmployeeRequest Employee { get; set; }
    }
}
