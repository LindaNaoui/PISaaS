using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class ClientViewModel
    {
        public int ClientID { get; set; }
        public  NomCompletViewModel  NomComplet{ get; set; }
        public string  Email { get; set; }
        public string  NumeroTel { get; set; }
    }
}