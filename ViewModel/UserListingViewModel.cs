using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessON.Common;
using FitnessON.Infra;

namespace FitnessON.ViewModel
{
    public class UserListingViewModel : NotificationClass, IUserListingContent
    {
        public string Header => "Ügyfél keresés";
    }
}
