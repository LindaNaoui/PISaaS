using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProjectViewModel
    {

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Phase> Phases { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public Team Team { get; set; }
        public Client C { get; set; }
    }
}