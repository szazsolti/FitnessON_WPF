using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Logic;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
            this.RenewLeaseCommand = new RelayCommand(this.RenewExecute);
        }
        public RelayCommand DeleteLeaseCommand
        {
            get;
            set;
        }

        public RelayCommand RenewLeaseCommand
        {
            get;
            set;
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


        public void RenewExecute()
        {
            if(this.selectedLease != null)
            {
                MainWindowViewModel.Instance.RenewLease(this.selectedLease,user);
            }
        }
        public void LogInExecute()
        {
            Data.Controller.CheckedValidDay(selectedLease);
            if (this.selectedLease != null)
            {
                if (Data.Controller.IsvalidLeaseDate(selectedLease))
                {
                    if (!Data.Controller.CheckedValidDay(selectedLease))
                    {
                        System.Windows.MessageBox.Show("Ön ezen a napon nem léphet be!", "A bérlete ma nem érvényes!");
                    }
                    else if (!Data.Controller.CheckedValidHour(selectedLease))
                    {
                        System.Windows.MessageBox.Show("Ön ebben az órában nem léphet be!", "A bérlete most nem érvényes!");
                    }
                    else if (!Data.Controller.CountEntryPerDay(selectedLease, user))
                    {
                        System.Windows.MessageBox.Show("Ön ma többször már nem léphet be!", "A bérlete most nem érvényes!");
                    }
                    else if (selectedLease.NumberOfEntries == 2)
                    {
                        System.Windows.MessageBox.Show("Már csak egyszeri belépésre van lehetősége!", "Bérlete hamarosan lejár");
                        int number = selectedLease.NumberOfEntries;
                        int id = selectedLease.Id;
                        selectedLease.NumberOfEntries -= 1;
                        selectedLease.inUse = true;
                        number -= 1;
                        Data.Controller.UpdateLeaseNumberOfEntriesAsync(number, id, true);
                        Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");

                    }
                    else if (selectedLease.NumberOfEntries == 1)
                    {
                        System.Windows.MessageBox.Show("Ez az utolsó belépési lehetősége!", "Bérlete lejár");
                        int number = selectedLease.NumberOfEntries;
                        int id = selectedLease.Id;
                        selectedLease.NumberOfEntries -= 1;
                        selectedLease.inUse = true;
                        number -= 1;
                        Data.Controller.UpdateLeaseNumberOfEntriesAsync(number, id, true);
                        Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                    }
                    else if (selectedLease.NumberOfEntries < 1)
                    {
                        System.Windows.MessageBox.Show("Ez a bérlet nem érvényes többszöri belépésre!", "Lejárt bérlet");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Sikeres belépés!", "Jó testmozgást!");
                        int number = selectedLease.NumberOfEntries;
                        int id = selectedLease.Id;
                        selectedLease.NumberOfEntries -= 1;
                        selectedLease.inUse = true;
                        number -= 1;
                        Data.Controller.UpdateLeaseNumberOfEntriesAsync(number, id, true);
                        Data.Controller.InsertToLog(user, selectedLease, "Belépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                    }
                    GetLeasesExecute();
                }
                else
                {
                    System.Windows.MessageBox.Show("Az Ön bérlete lejárt!", "Lejárt bérlet");
                }
            }
        }

        public void LogOutExecute()
        {
            if (this.SelectedLease != null)
            {
                System.Windows.MessageBox.Show("Köszönjük, hogy minket választott!", "Viszontlátásra");
                int number = selectedLease.NumberOfEntries;
                int id = selectedLease.Id;
                selectedLease.inUse = false;
                Data.Controller.UpdateLeaseNumberOfEntriesAsync(number, id, false);
                Data.Controller.InsertToLog(user, selectedLease, "Kilépett a(z) " + selectedLease.MixLease.Name + " nevű bérlettel.");
                GetLeasesExecute();
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
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        private void TimestampToDate()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            foreach (var item in this.UserLeases)
            {
               // Console.WriteLine("date "+UnixTimeStampToDateTime(Convert.ToDouble(item.StartValidity)));
                if (!item.StartValidity.Contains("-") && !item.StartValidity.Contains("/") && !item.StartValidity.Equals("0") && !item.EndValidity.Equals("0"))
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
