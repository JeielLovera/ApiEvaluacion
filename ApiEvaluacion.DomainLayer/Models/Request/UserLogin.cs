using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class UserLogin
    {
        [Required(ErrorMessage = "El email no puede ser nulo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no puede ser nulo")]
        public string Password { get; set; }
    }
}
