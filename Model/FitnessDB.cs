using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApplication.Model
{
    public class FitnessDB:DbContext
    {
        public FitnessDB():base("name=DefaultConnection")
        {

        }

        public DbSet<User> Person { get; set; }
    }
}
