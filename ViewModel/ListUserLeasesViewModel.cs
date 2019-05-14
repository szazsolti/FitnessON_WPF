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
            this.NewLease = new RelayCommand(this.CreateNewLeaseExecute);
            this.RefreshLeases = new RelayCommand(this.GetLeasesExecute);
            this.LogInCommand = new RelayCommand(this.LogInExecute);
            this.LogOutCommand = new RelayCommand(this.LogOutExecute);
        }

        public RelayCommand RefreshLeases
        {
            get;
            set;
        }

        public RelayCommand LogInCommand
        {
            get;
            set;
        }

        public RelayCommand LogOutCommand
        {
            get;
            set;
        }
        public RelayCommand NewLease
        {
            get;
            set;
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
                GetLeasesExecute();
                TimestampToDate();
                this.OnProprtyChanged();
            }
        }

        public void LogInExecute()
        {
            
        }

        public void LogOutExecute()
        {

        }

        public void CreateNewLeaseExecute()
        {
            MainWindowViewModel.Instance.CreateNewLease(this.user);
        }
        private void TimestampToDate()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            foreach (var item in this.UserLeases)
            {
                if (!item.StartValidity.Contains("-") && !item.StartValidity.Contains("/"))
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

        public void GetLeasesExecute()
        {
            this.UserLeases = Data.Controller.GetUserLeases(this.user.Card_Id);
            Console.WriteLine("Leases: " + leases.Count);
        }

        public string Header => "Bérleteim";
    }
}
