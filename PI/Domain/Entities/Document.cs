﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class Document
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
       
      

    }
}
