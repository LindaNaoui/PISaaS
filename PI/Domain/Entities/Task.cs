using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{ public enum status {  Doing, Done, Todo }

    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Duration { get; set; }
        public string Estimation { get; set; }
        public string Description { get; set; }
        public status Status { get; set; }
        public Task T { get; set; }

    }
}
