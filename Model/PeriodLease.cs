﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApplication.Model
{
    class PeriodLease
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
    }
}
