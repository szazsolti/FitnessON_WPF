﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class IntermediateLease
    {
        [Key]
        public int I_Id { get; set; }
        public string Card_Id { get; set; }
        public int Lease_Id { get; set; }
        public virtual Lease Lease { get; set; }
    }
}
