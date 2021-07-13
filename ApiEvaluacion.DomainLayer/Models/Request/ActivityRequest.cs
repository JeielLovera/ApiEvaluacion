using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class ActivityRequest
    {
        [Required(ErrorMessage = "El nombre de la actividad/procedimiento no puede ser nulo")]
        [MaxLength(100, ErrorMessage = "El nombre de la actividad/procedimiento no puede contener más de 100 caracteres")]
        public string NameActivity { get; set; }
    }
}
