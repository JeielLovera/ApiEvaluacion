using System;
using System.Collections.Generic;
using System.Text;

namespace ApiEvaluacion.DomainLayer.Models.Response
{
    public class UserToken
    {
        public string EmailUser { get; set; }
        public string NamesUser { get; set; }
        public string RoleUser { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
