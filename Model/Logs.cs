using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApplication.Model
{
    class Logs
    {
        [Key]
        public int Log_Id { get; set; }
        public long Time { get; set; }
        public User User{ get; set; }
        public Lease Lease { get; set; }
        public string Message { get; set; }
    }
}
