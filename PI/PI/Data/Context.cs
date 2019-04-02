using Data.Configurations;
using Data.Conventions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Context :DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Add(new KeyConvention());
            modelBuilder.Conventions.Add(new DateTimeConvention());
           // modelBuilder.Configurations.Add(new DocumentConfiguration());
          
            //TPT Stratégie d'heritage
            //modelBuilder.Entity<Adherant>().ToTable("Adherant");
            //modelBuilder.Entity<Professeur>().ToTable("Professeur");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Domain.Entities.Task>().ToTable("Task");
           
        }

    }
}
