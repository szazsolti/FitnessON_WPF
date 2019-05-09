using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class NumberOfEntriesLease
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
