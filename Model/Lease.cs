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
        public int MixLeases_Id { get; set; }
        public virtual MixLease MixLease { get; set; }
        public int Card_Id { get; set; }
        public virtual Card Card { get; set; }
        public string StartValidity { get; set; }
        public string EndValidity { get; set; }
        public int NumberOfEntries { get; set; }
        public bool inUse { get; set; }
    }
}
