using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Logic;
using FitnessON.Model;

namespace FitnessON.ViewModel
{
    public class UserListingViewModel : NotificationClass, IUserListingContent
    {
        public List<User> users=new List<User>();
        public string Header => "Ügyfél keresés";

        public UserListingViewModel()
        {
            GetUsers();
            this.RefreshUsers = new RelayCommand(this.RefreshUsersExecute);
        }

        public List<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
                this.OnProprtyChanged();
            }
        }

        public void GetUsers()
        {
            this.users = Data.Controller.GetUsers();
        }


        public RelayCommand RefreshUsers
        {
            get;
            set;
        }

        public void RefreshUsersExecute()
        {
            GetUsers();
        }

    }
}
