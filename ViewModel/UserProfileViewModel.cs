using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Logic;
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
        private User loggedInUser = new User();

        public UserProfileViewModel()
        {
            this.OpenLeasesCommand = new RelayCommand(this.OpenLeasesCommandExecute);
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

        public string UserName
        {
            get
            {
                return this.loggedInUser.Name;
            }
            
        }

        public string EmailAddress
        {
            get
            {
                return this.loggedInUser.Email;
            }

        }

        public string PhoneNumber
        {
            get
            {
                return this.loggedInUser.Phone;
            }

        }

        public string CardNumber
        {
            get
            {
                return Data.Controller.GetCardNumber(this.loggedInUser.Card_Id);
            }

        }

        public string ProfilePicture
        {
            get
            {
                return this.loggedInUser.Picture;
            }

        }

        public string Header => "Saját profilom";

        public RelayCommand OpenLeasesCommand
        {
            get;
            set;
        }

        private void OpenLeasesCommandExecute()
        {
            MainWindowViewModel.Instance.SetUserToListUserLeases(this.loggedInUser);
        }
    }
}
