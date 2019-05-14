﻿using FitnessON.Common;
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
        private Lease selectedLease;

        public ListUserLeasesViewModel()
        {
            this.NewLeaseCommand = new RelayCommand(this.CreateNewLeaseExecute);
            this.RefreshLeasesCommand = new RelayCommand(this.GetLeasesExecute);
            this.LogInCommand = new RelayCommand(this.LogInExecute, this.LogInCanExecute);
            this.LogOutCommand = new RelayCommand(this.LogOutExecute, this.LogOutCanExecute);
        }

        public RelayCommand RefreshLeasesCommand
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
        public RelayCommand NewLeaseCommand
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
            if(this.selectedLease != null)
            {
                Console.WriteLine("Valasztott neve: " + selectedLease.MixLease.Name);
                if(selectedLease.NumberOfEntries == 2)
                {
                    System.Windows.MessageBox.Show("Már csak egyszeri belépésre van lehetősége!", "Bérlete hamarosan lejár");
                    selectedLease.NumberOfEntries -= 1;
                    selectedLease.inUse = true;
                    Data.Controller.UpdateLeaseNumberOfEntriesAsync(selectedLease);
                    Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                    
                }
                else if (selectedLease.NumberOfEntries == 1)
                {
                    System.Windows.MessageBox.Show("Ez az utolsó belépési lehetősége!", "Bérlete lejár");
                    selectedLease.NumberOfEntries -= 1;
                    selectedLease.inUse = true;
                    Data.Controller.UpdateLeaseNumberOfEntriesAsync(selectedLease);
                    Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                }
                else if (selectedLease.NumberOfEntries < 1)
                {
                    System.Windows.MessageBox.Show("Ez a bérlet nem érvényes többszöri belépésre!", "Lejárt bérlet");
                }
                else
                {
                    System.Windows.MessageBox.Show("Sikeres belépés!", "Jó testmozgást!");
                    selectedLease.NumberOfEntries -= 1;
                    selectedLease.inUse = true;
                    Data.Controller.UpdateLeaseNumberOfEntriesAsync(selectedLease);
                    Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                }
            }
        }

        public void LogOutExecute()
        {
            if (this.SelectedLease != null)
            {
                System.Windows.MessageBox.Show("Köszönjük, hogy minket választott!", "Viszontlátásra");
                selectedLease.inUse = false;
                Data.Controller.UpdateLeaseNumberOfEntriesAsync(selectedLease);
                Data.Controller.InsertToLog(user, selectedLease, "Kilépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
            }
        }

        public bool LogInCanExecute()
        {
            if(selectedLease != null && !selectedLease.inUse)
            {
                return true;
            }
            else if(selectedLease == null)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool LogOutCanExecute()
        {
            if (selectedLease != null && selectedLease.inUse)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            //Console.WriteLine("Leases: " + leases.Count);
        }

        public string Header => "Bérleteim";
        
        public Lease SelectedLease
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

    }
}
