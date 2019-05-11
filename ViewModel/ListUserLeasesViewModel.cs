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
    public class ListUserLeasesViewModel : NotificationClass, IListUserLeasesContent
    {
        private User user;


        public ListUserLeasesViewModel()
        {

        }


        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
                this.OnProprtyChanged();
            }
        }



        public string Header => "Bérleteim";
    }
}
