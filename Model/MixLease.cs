using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class MixLease
    {
        [Key]
        public int Id { get; set; }
        public int PeriodLease_Id { get; set; }
        public PeriodLease PeriodLease { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public string Days { get; set; }
        public int NumberOfEntriesLease_Id { get; set; }
        public NumberOfEntriesLease NumberOfEntriesLease { get; set; }
        public int Enter_day { get; set; }
    }
}
