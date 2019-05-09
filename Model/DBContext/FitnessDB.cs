using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class FitnessDB:DbContext
    {
        public FitnessDB():base("name=FitnessDB")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<IntermediateLease> IntermediateLeases { get; set; }
        public DbSet<LeaseTypes> LeaseTypes { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<MixLease> MixLeases { get; set; }
        public DbSet<NumberOfEntriesLease> NumberOfEntriesLeases { get; set; }
        public DbSet<PeriodLease> PeriodLeases { get; set; }
    }
}
