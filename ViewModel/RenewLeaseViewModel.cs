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
    class RenewLeaseViewModel : NotificationClass, IRenewLeaseContent
    {
        private Lease selectedLease;
        private User user;
        private List<Lease> leases = new List<Lease>();
        private string date;
        public string Header => "Bérletújitás";

        public RenewLeaseViewModel()
        {
            this.ApplyCommand = new RelayCommand(this.ApplyRenewCommandExecute);
        }

        public void ApplyRenewCommandExecute()
        {
            Data.Controller.UpdateEndValidity(selectedLease, date, user);
            this.selectedLease.EndValidity = date;
            this.selectedLease.NumberOfEntries = Data.Controller.GetNumberOfEntries(selectedLease);
            System.Windows.MessageBox.Show("Bérlet megújitva!", "Sikeres művelet");
        }
        public RelayCommand ApplyCommand
        {
            get;
            set;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = Convert.ToDateTime(value).ToString("yyyy/MM/dd") + " 0:00 PM";
                this.OnProprtyChanged();
            }
        }

        public Lease SelectedLease
        {
            get
            {
                return this.selectedLease;
            }
            set
            {
                this.selectedLease = value;
                this.leases.Add(this.selectedLease);
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
                this.OnProprtyChanged();
            }
        }
        public List<Lease> Leases
        {
            get
            {
                return this.leases;
            }
            set
            {
                this.leases=value;
                this.OnProprtyChanged();
            }
        }

    }
}
