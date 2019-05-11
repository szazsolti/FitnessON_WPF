using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessON.Infra;
using System.Threading.Tasks;
using FitnessON.Common;

namespace FitnessON.ViewModel
{
    public class EntriesListingWithFilterViewModel : NotificationClass, IEntriesListingWithFilterContent
    {
        public string Header => "Belépés listázás";
    }
}
