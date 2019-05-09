using MVVMApplication.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApplication.Model
{
    public class User:NotificationClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Card_Id { get; set; }
        public string Picture { get; set; }
        public string Permission { get; set; }
       
    }

  
}
