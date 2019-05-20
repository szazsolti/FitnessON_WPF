using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitnessON.Infra;
using System.Threading.Tasks;
using FitnessON.Common;
using FitnessON.Model;
using FitnessON.Logic;

namespace FitnessON.ViewModel
{
    public class EntriesListingWithFilterViewModel : NotificationClass, IEntriesListingWithFilterContent
    {
        private List<Logs> logs;
        private String inputText;
        private bool client = true;
        private bool card = false;
        private bool type =false;
        private bool date=false;
        private string dateTime;


        public EntriesListingWithFilterViewModel()
        {
            this.logs = Data.Controller.GetLogs();
            this.ApplyFilterCommand = new RelayCommand(this.ApplyFilterCommandExecute);
            this.ListAllCommand = new RelayCommand(this.ListAllCommandExecute);
        }

        public string DateTime
        {
            get
            {
                return this.dateTime;
            }
            set
            {
                this.dateTime = Convert.ToDateTime(value).ToString("yyyy/MM/dd")+" 0:00 PM";
                this.OnProprtyChanged();
            }
        }
        public List<Logs> Logs
        {
            get
            {
                return this.logs;
            }
            set
            {
                this.logs = value;
                this.OnProprtyChanged();
            }
        }
        public RelayCommand ApplyFilterCommand
        {
            get;
            set;
        }

        public RelayCommand ListAllCommand
        {
            get;
            set;
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

        public bool Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
                this.OnProprtyChanged();
            }
        }

        public bool Card
        {
            get
            {
                return this.card;
            }
            set
            {
                this.card = value;
                this.OnProprtyChanged();
            }
        }

        public bool Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                this.OnProprtyChanged();
            }
        }

        public bool Date
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

        public void ApplyFilterCommandExecute()
        {
            if (client)
            {
                this.Logs = Data.Controller.GetLogsWithUserFilter(inputText);
            }
            else if (card)
            {
                this.Logs = Data.Controller.GetLogsWithCardFilter(inputText);
            }
            else if(type)
            {
                this.Logs = Data.Controller.GetLogsWithTypeFilter(inputText);
            }
            else if (date && DateTime != null && !DateTime.Equals(""))
            {
                this.Logs = Data.Controller.GetLogsWithDateFilter(DateTime);
            }
        }

        public void ListAllCommandExecute()
        {
            this.Logs = Data.Controller.GetLogs();
        }

        public string Header => "Belépés listázás";
    }
}
