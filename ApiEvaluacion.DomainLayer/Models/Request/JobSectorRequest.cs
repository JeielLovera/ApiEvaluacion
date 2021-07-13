using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class JobSectorRequest
    {
        [Required(ErrorMessage = "El nombre del trabajo/sector no puede ser nulo")]
        [MaxLength(100, ErrorMessage = "El nombre del trabajo/sector no puede contener más de 100 caracteres")]
        public string NameJob { get; set; }
    }
}
