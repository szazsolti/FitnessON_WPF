using FitnessON.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Card_Id { get; set; }
        public virtual Card Card { get; set; }
        public string Picture { get; set; }
        public string Permission { get; set; }
       
    }

  
}
