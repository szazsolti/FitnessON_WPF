using FitnessON.Common;
using FitnessON.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    public class AdminProfileViewModel: NotificationClass,IAdminProfileContent
    {
        public AdminProfileViewModel() { }

        public string Header => "Admin menü";
    }
}
