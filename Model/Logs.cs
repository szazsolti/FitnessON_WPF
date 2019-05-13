using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class Logs
    {
        [Key]
        public int Log_Id { get; set; }
        public long Time { get; set; }
        public int User_Id { get; set; }
        public virtual User User { get; set; }
        public int Lease_Id { get; set; }
        public virtual Lease Lease { get; set; }
        public string Message { get; set; }
    }
}
