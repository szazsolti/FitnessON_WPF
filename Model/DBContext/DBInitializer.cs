using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model.DBContext
{
    public class DBInitializer : DropCreateDatabaseAlways<FitnessDB>
    {
        protected override void Seed(FitnessDB context)
        {
            this.AddUsers(context);
            this.AddNumberOfEntriesLeases(context);
            this.AddPeriodLeases(context);
            this.AddMixLease(context);
            this.AddLeaseTypes(context);
            this.AddLease(context);
            this.AddIntermediateLease(context);
        }

        private void AddUsers(FitnessDB context)
        {
            context.User.Add(new User { Id = 1, Name = "Pistike", Phone = "+40757485983", Email="pistike@admin.com", Card_Id="1as58e597d", Picture = "https://i.ibb.co/5rdrFNS/Jerry-Mouse.png", Permission="user"});
            context.User.Add(new User { Id = 2, Name = "Joska", Phone = "+40754859553", Email = "joska@user.com", Card_Id = "i5h2f58r2d5", Picture = "https://i.ibb.co/zPTPtmP/tom.png", Permission = "user" });
            context.User.Add(new User { Id = 3, Name = "Gazsi", Phone = "+40751412598", Email = "Gazsi@user.com", Card_Id = "admin", Picture = "https://i.ibb.co/mSVHsDT/lumpy.png", Permission = "admin" });
        }

        private void AddNumberOfEntriesLeases(FitnessDB context) {
            context.NumberOfEntriesLeases.Add(new NumberOfEntriesLease { Id = 1, Quantity = 10 });
            context.NumberOfEntriesLeases.Add(new NumberOfEntriesLease { Id = 2, Quantity = 20 });
            context.NumberOfEntriesLeases.Add(new NumberOfEntriesLease { Id = 3, Quantity = 30 });
        }

        private void AddPeriodLeases(FitnessDB context)
        {
            context.PeriodLeases.Add(new PeriodLease { Id = 1, NumberOfDays = 10 });
            context.PeriodLeases.Add(new PeriodLease { Id = 2, NumberOfDays = 20 });
            context.PeriodLeases.Add(new PeriodLease { Id = 3, NumberOfDays = 30 });
        }

        private void AddMixLease(FitnessDB context)
        {
            context.MixLeases.Add(new MixLease { Id = 1, PeriodLease_Id = 1, StartHour = 8, EndHour = 10, Days = "12345", NumberOfEntriesLease_Id = 1, Enter_day = 0});
            context.MixLeases.Add(new MixLease { Id = 2, PeriodLease_Id = 2, StartHour = 0, EndHour = 24, Days = "67", NumberOfEntriesLease_Id = 2, Enter_day = 1 });
            context.MixLeases.Add(new MixLease { Id = 3, PeriodLease_Id = 2, StartHour = 10, EndHour = 12, Days = "24", NumberOfEntriesLease_Id = 1, Enter_day = 3 });
        }

        private void AddLeaseTypes(FitnessDB context)
        {
            context.LeaseTypes.Add(new LeaseTypes { Id = 1, Name = "PeriodLease", LeaseType_Id = 1, Price = 200.0 });
            context.LeaseTypes.Add(new LeaseTypes { Id = 2, Name = "NumberOfEntriesLease", LeaseType_Id = 2, Price = 110.0 });
            context.LeaseTypes.Add(new LeaseTypes { Id = 3, Name = "MixLease", LeaseType_Id = 3, Price = 100.0 });
            context.LeaseTypes.Add(new LeaseTypes { Id = 4, Name = "PeriodLease", LeaseType_Id = 2, Price = 320.0 });

        }

        private void AddLease(FitnessDB context)
        {
            context.Leases.Add(new Lease { Id = 1, LeaseTypes_Id = 1, StartValidity = 1559399069000, EndValidity = 1561991069000, NumberOfEntries = 10 });
            context.Leases.Add(new Lease { Id = 2, LeaseTypes_Id = 3, StartValidity = 1564669469000, EndValidity = 1567347869000, NumberOfEntries = 10 });
            context.Leases.Add(new Lease { Id = 3, LeaseTypes_Id = 2, StartValidity = 0, EndValidity = 0, NumberOfEntries = 20 });
        }

        private void AddIntermediateLease(FitnessDB context)
        {
            context.IntermediateLeases.Add(new IntermediateLease { Lease_Id = 1, Card_Id = "1as58e597d" });
            context.IntermediateLeases.Add(new IntermediateLease { Lease_Id = 1, Card_Id = "admin" });
        }
    }
}
