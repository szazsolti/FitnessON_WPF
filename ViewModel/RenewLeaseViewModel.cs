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
        private List<Lease> leases = new List<Lease>();
        private DateTime date;
        public string Header => "Bérletújitás";

        public RenewLeaseViewModel()
        {
            date = DateTime.Now;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
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
                Console.WriteLine(selectedLease.EndValidity);
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
