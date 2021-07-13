using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Request
{
    public class QueryRoles
    {
        public IEnumerable<string> Roles { get; set; }
    }
}
