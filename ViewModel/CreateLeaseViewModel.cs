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
        private string date;
        private int entrieNumberIndex=-1;
        private int periodNumberIndex=-1;
        private List<MixLease> mixleases;
        private MixLease selectedLease;

        public string Header => "Bérletlértehozás";

        public CreateLeaseViewModel()
        {
            this.CreateLeaseCommand = new RelayCommand(this.CreateLeaseExecute,this.CreateLeaseCanExecute);
            this.ListAllLeas = new RelayCommand(this.GetAllLeaseExecute);
            EntrieNumber = Data.Controller.GetEntriesNumber();
            PeriodLeases = Data.Controller.GetPeriodLeasesNumber();
            Mixleases = Data.Controller.GetMixLeases();
        }

        public bool CreateLeaseCanExecute()
        {
            return (Date != null && !Date.Equals(""));
        }
        public void CreateLeaseExecute()
        {
            if (selectedLease != null )
            {
                Data.Controller.CreateLeaseForUser(Date, user.Card, selectedLease,user);
                System.Windows.MessageBox.Show("Ön sikeresen vásárolt egy bérletet!", "Nagy siker");
            }
        }

        public MixLease SelectedLease
        {
            get
            {
                return this.selectedLease;
            }
            set
            {
                this.selectedLease = value;
                this.OnProprtyChanged();
            }
        }
        public RelayCommand ListAllLeas { get; set; }
        public RelayCommand CreateLeaseCommand
        {
            get;
            set;
        }

        public int EntrieNumberIndex
        {
            get
            {
                return this.entrieNumberIndex;
            }
            set
            {
                this.entrieNumberIndex = value;
                this.OnProprtyChanged();
            }
        }
        public int PeriodNumberIndex
        {
            get
            {
                return this.periodNumberIndex;
            }
            set
            {
                this.periodNumberIndex = value;
                this.OnProprtyChanged();
            }
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
        public int EntrieNumberItem
        {
            get
            {
                return this.entrieNumberItem;
            }
            set
            {
                this.entrieNumberItem = value;
                PeriodNumberIndex = -1;
                if (entrieNumberItem >= 0)
                {
                    Mixleases = Data.Controller.GetMixLeasesEntriesFilter(entrieNumberItem);
                }  
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
                EntrieNumberIndex = -1;
                this.periodLeaseItem = value;
                if(periodLeaseItem >= 0)
                {
                    Mixleases = Data.Controller.GetMixLeasesValidityFilter(periodLeaseItem);
                }
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

        public void GetAllLeaseExecute()
        {
            PeriodNumberIndex = -1;
            EntrieNumberIndex = -1;
            Mixleases = Data.Controller.GetMixLeases();
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
