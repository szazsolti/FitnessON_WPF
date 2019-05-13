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
                GetLeases();
                TimestampToDate();
                this.OnProprtyChanged();
            }
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

        private void TimestampToDate()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            foreach (var item in this.leases)
            {
                if (!item.StartValidity.Contains("/"))
                {
                    dateTime = dateTime.AddSeconds(Convert.ToDouble(item.StartValidity));
                    string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                    item.StartValidity = printDate;
                    dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

                    dateTime = dateTime.AddSeconds(Convert.ToDouble(item.EndValidity));
                    printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                    item.EndValidity = printDate;
                    dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                }
            }
        }

        public void GetLeases()
        {
            this.leases = Data.Controller.GetUserLeases(this.user.Card_Id);
            Console.WriteLine("Leases: " + leases.Count);
        }

        public string Header => "Bérleteim";
    }
}
