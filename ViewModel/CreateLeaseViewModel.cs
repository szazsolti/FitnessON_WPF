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
    public class CreateLeaseViewModel : NotificationClass, ICreateUserLeaseContent
    {
        private User user;
        private int entrieNumberItem;
        private int periodLeaseItem;
        private List<int> entrieNumber;
        private List<int> periodLeases;
        private DateTime date;
        private List<MixLease> mixleases;

        public string Header => "Bérletlértehozás";

        public CreateLeaseViewModel()
        {
            this.CreateLeaseCommand = new RelayCommand(this.CreateLeaseExecute);
            EntrieNumber = Data.Controller.GetEntriesNumber();
            PeriodLeases = Data.Controller.GetPeriodLeasesNumber();
            Mixleases = Data.Controller.GetMixLeases();
            date = DateTime.Now;
        }

        public void CreateLeaseExecute()
        {

        }
        public RelayCommand CreateLeaseCommand
        {
            get;
            set;
        }

        public List<MixLease> Mixleases
        {
            get
            {
                return this.mixleases;
            }
            set
            {
                this.mixleases = value;
                this.OnProprtyChanged();
            }
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
        public int EntrieNumberItem
        {
            get
            {
                return this.entrieNumberItem;
            }
            set
            {
                this.entrieNumberItem = value;
                Mixleases = Data.Controller.GetMixLeasesEntriesFilter(entrieNumberItem);
                this.OnProprtyChanged();
            }
        }

        public int PeriodLeaseItem
        {
            get
            {
                return this.periodLeaseItem;
            }
            set
            {
                this.periodLeaseItem = value;
                Mixleases = Data.Controller.GetMixLeasesValidityFilter(periodLeaseItem);
                this.OnProprtyChanged();
            }
        }

        public List<int> EntrieNumber
        {
            get
            {
                return this.entrieNumber;
            }
            set
            {
                this.entrieNumber = value;
                this.OnProprtyChanged();
            }
        }

        public List<int> PeriodLeases
        {
            get
            {
                return this.periodLeases;
            }
            set
            {
                this.periodLeases = value;
                this.OnProprtyChanged();
            }
        }

        public User User {
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

    }
}
