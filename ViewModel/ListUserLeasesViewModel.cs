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
    public class ListUserLeasesViewModel : NotificationClass, IListUserLeasesContent
    {
        private User user;
        private List<Lease> leases = new List<Lease>();


        public ListUserLeasesViewModel()
        {

        }

        public List<Lease> UserLeases
        {
            get
            {
                return this.leases;
            }
            set
            {
                this.leases = value;
                this.OnProprtyChanged();
            }
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
                //GetLeases();
                this.OnProprtyChanged();
            }
        }

        public void GetLeases()
        {
            this.leases = Data.Controller.GetUserLeases(this.user.Card_Id);
            Console.WriteLine("User cardid: " + user.Name);
        }



        public string Header => "Bérleteim";
    }
}
