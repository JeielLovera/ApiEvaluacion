using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public int JobSectorId { get; set; }
        public int SupervisorId { get; set; }
        public bool Supervised { get; set; }
        public string Comment { get; set; }
        public DateTime DateQuestionnaire { get; set; }
    }
}
