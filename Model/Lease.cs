using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class Lease
    {
        [Key]
        public int Id { get; set; }
        public int LeaseTypes_Id { get; set; }
        public LeaseTypes LeaseTypes { get; set; }
        public long StartValidity { get; set; }
        public long EndValidity { get; set; }
        public int NumberOfEntries { get; set; }
    }
}
