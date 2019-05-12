using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    public class AdminProfileViewModel: NotificationClass, IAdminProfileContent
    {
        private User adminUser;
        public AdminProfileViewModel() {
            this.OpenUserListing = new RelayCommand(this.OpenUserListingTab);
            this.OpenLeaseListing = new RelayCommand(this.OpenLeaseListingTab);
            this.OpenEntriesListing = new RelayCommand(this.OpenEntriesListingTab);
        }

        public RelayCommand OpenUserListing
        {
            get;
            set;
        }

        public RelayCommand OpenLeaseListing
        {
            get;
            set;
        }

        public RelayCommand OpenEntriesListing
        {
            get;
            set;
        }

        public void OpenUserListingTab()
        {
                if (this.adminUser.Permission.Equals("admin"))
                {
                        MainWindowViewModel.Instance.SetUserListing();
                }  
        }

        public void OpenLeaseListingTab()
        {
            if (this.adminUser.Permission.Equals("admin"))
            {
                MainWindowViewModel.Instance.SetLeaseListing();
            }
        }

        public void OpenEntriesListingTab()
        {
            if (this.adminUser.Permission.Equals("admin"))
            {
                MainWindowViewModel.Instance.SetEntriesListing();
            }
        }

        public User Admin
        {
            get
            {
                return this.adminUser;
            }
            set
            {
                this.adminUser = value;
                this.OnProprtyChanged();
            }
        }

        public string Header => "Admin menü";
    }
}
