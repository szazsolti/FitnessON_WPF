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
            GetLeases();
            //Console.WriteLine("User: " + user.Name);
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

        public void GetLeases()
        {
            this.leases = Data.Controller.GetUserLeases(this.user.Card_Id);
            Console.WriteLine("Berletek szama: " + leases.Count);
        }

        public string Header => "Bérleteim";
    }
}
