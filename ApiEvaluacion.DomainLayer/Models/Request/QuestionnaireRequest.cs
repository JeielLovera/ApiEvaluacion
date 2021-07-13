using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class QuestionnaireRequest
    {
        [Required(ErrorMessage = "El email del usuario no puede ser nulo")]        
        public string EmailUser { get; set; }

        [Required(ErrorMessage = "La actividad/procedimiento no puede ser nulo")]
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "El trabajo/sector no puede ser nulo")]
        public int JobSectorId { get; set; }

        [Required(ErrorMessage = "El supervisor no puede ser nulo")]
        public int SupervisorId { get; set; }

        [Required(ErrorMessage = "El supervisión no puede ser nulo")]
        public bool Supervised { get; set; }

        [Required(ErrorMessage = "El comentario no puede ser nulo")]
        public string Comment { get; set; }
    }
}
