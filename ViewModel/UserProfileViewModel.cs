using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    public class UserProfileViewModel : NotificationClass, IProfileContent
    {
        private User loggedInUser;

        public UserProfileViewModel()
        {

        }

        public User User
        {
            get
            {
                return this.loggedInUser;
            }
            set
            {
                this.loggedInUser = value;
                this.OnProprtyChanged();
            }
        }


        public string Header => "Saját profilom";
    }
}
