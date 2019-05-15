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
    public class LeaseListingWithFilterViewModel : NotificationClass, ILeaseListingWithFilterContent
    {
        public string Header => "Bérlet keresés";
        private List<Lease> leases = new List<Lease>();
        private String inputText;
        private bool activeLeases = true;
        private bool inactivLeases = false;
        private bool leaseTypes = false;
        private bool invalidLeases = false;

        public LeaseListingWithFilterViewModel()
        {
            this.ListAllCommand = new RelayCommand(this.ListAllCommandExecute);
            this.ApplyFilterCommand = new RelayCommand(this.ApplyFilterCommandExecute);
        }

        public RelayCommand ListAllCommand
        {
            get;
            set;
        }

        public RelayCommand ApplyFilterCommand
        {
            get;
            set;
        }

        public void ListAllCommandExecute()
        {
            this.Leases = Data.Controller.GetLeases();
        }

        public void ApplyFilterCommandExecute()
        {
            if (activeLeases)
            {
                this.Leases = Data.Controller.GetLeasesWithStatusFilter(true);
            }
            else if (inactivLeases)
            {
                this.Leases = Data.Controller.GetLeasesWithStatusFilter(false);
            }
            else if (leaseTypes)
            {
                this.Leases = Data.Controller.GetLeasesWithTypeFilter(inputText);
            }
            else if (invalidLeases)
            {
                this.Leases = Data.Controller.GetInvalidLeases();
            }
        }

        public bool InvalidLeases
        {
            get
            {
                return this.invalidLeases;
            }
            set
            {
                this.invalidLeases = value;
                this.OnProprtyChanged();
            }
        }
        public bool LeaseTypes
        {
            get
            {
                return this.leaseTypes;
            }
            set
            {
                this.leaseTypes = value;
                this.OnProprtyChanged();
            }
        }

        public bool InactivLeases
        {
            get
            {
                return this.inactivLeases;
            }
            set
            {
                this.inactivLeases = value;
                this.OnProprtyChanged();
            }
        }
        public bool ActiveLeases
        {
            get
            {
                return this.activeLeases;
            }
            set
            {
                this.activeLeases = value;
                this.OnProprtyChanged();
            }
        }

        public String InputText
        {
            get
            {
                return this.inputText;
            }
            set
            {
                this.inputText = value;
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
                this.leases = value;
                this.OnProprtyChanged();
            }
        }

    }
}
