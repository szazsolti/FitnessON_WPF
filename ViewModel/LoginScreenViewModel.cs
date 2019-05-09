using FitnessON.Infra;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    class LoginScreenViewModel:NotificationClass
    {
        private List<User> users = new List<User>();


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

    }
}
