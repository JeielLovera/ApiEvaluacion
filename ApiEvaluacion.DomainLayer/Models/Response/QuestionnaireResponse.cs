using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Response
{
    public class QuestionnaireResponse
    {
        public int Id { get; set; }        
        public string NamesEmployee { get; set; }
        public string NameActivity { get; set; }
        public string NameJob { get; set; }
        public string NamesSupervisor { get; set; }
        public bool Supervised { get; set; }
        public string Comment { get; set; }
        public DateTime DateQuestionnaire { get; set; }

    }
}
