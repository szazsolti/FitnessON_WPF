using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Logic
{
    public static class Data
    {
        static Data()
        {
            Controller = new Controller();
        }
        public static Controller Controller { get; }
    }
}
