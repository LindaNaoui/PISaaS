using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Conventions
{
   public class KeyConvention : Convention
    {
        public KeyConvention()
        {
            this.Properties<DateTime>().Configure(e => e.HasColumnType("datetime2"));

        }
          
    }
}
