﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class Client
    { public int Clientid { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public  string Email { get; set; }
        public  string PhoneNumber { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public Manager M { get; set; }
    }
}
