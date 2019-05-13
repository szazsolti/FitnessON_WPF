
namespace FitnessON.ViewModel
{
    using FitnessON.Common;
    using FitnessON.Infra;
    using FitnessON.Logic;
    using FitnessON.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    //MainWindowViewModel:NotificationClass
    public class MainWindowViewModel : NotificationClass
    {
        public static Controller Controller;
        private ObservableCollection<IFitnessContent> contents;
        private IFitnessContent selectedContent;
        private List<string> openedHeaders = new List<string>();

        public MainWindowViewModel()
        {
            Instance = this;
            Controller = new Controller();
            this.GenerateContents();
        }

        public static MainWindowViewModel Instance { get; private set; }
        public EventHandler ShowMessageBox = delegate { };

        public ObservableCollection<IFitnessContent> Contents
        {
            get
            {
                return this.contents;
            }
            set
            {
                this.contents = value;
                this.OnProprtyChanged();
            }
        }

        public IFitnessContent SelectedContent
        {
            get
            {
                return this.selectedContent;
            }
            set
            {
                this.selectedContent = value;
                this.OnProprtyChanged();
            }
        }

        private void GenerateContents()
        {
            this.Contents = new ObservableCollection<IFitnessContent>();
            IFitnessContent loginScreenViewModel = new LoginScreenViewModel();
            this.Contents.Add(loginScreenViewModel);
            this.SelectedContent = this.Contents.First();
        }

        public void SetUserToProfile(User user)
        {
            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            userProfileViewModel.User = user;
            this.Contents.Add(userProfileViewModel);
            this.selectedContent = this.Contents.Last();
            this.Contents.Remove(this.Contents.First());
            addHeader(userProfileViewModel.Header);
            SetAdminToProfile(user);


        }



        private void SetAdminToProfile(User user)
        {
            if (user.Permission.Equals("admin"))
            {
                AdminProfileViewModel adminProfileViewModel = new AdminProfileViewModel();
                adminProfileViewModel.Admin = user;
                this.Contents.Add(adminProfileViewModel);
                addHeader(adminProfileViewModel.Header);
            }
        }

        public void SetLeaseListing()
        {
            LeaseListingWithFilterViewModel leaseListingWithFilterView = new LeaseListingWithFilterViewModel();
            if (!checkIfHeaderIsOpened(leaseListingWithFilterView.Header))
            {
                this.Contents.Add(leaseListingWithFilterView);
                addHeader(leaseListingWithFilterView.Header);
            }   
        }

        public void SetUserListing()
        {
            UserListingViewModel userListingViewModel = new UserListingViewModel();
            if (!checkIfHeaderIsOpened(userListingViewModel.Header))
            {
                this.Contents.Add(userListingViewModel);
                addHeader(userListingViewModel.Header);
            }

                
        }

        public void SetEntriesListing()
        {
            EntriesListingWithFilterViewModel entriesListingWithFilterViewModel = new EntriesListingWithFilterViewModel();
            if (!checkIfHeaderIsOpened(entriesListingWithFilterViewModel.Header))
            {
                this.Contents.Add(entriesListingWithFilterViewModel);
                addHeader(entriesListingWithFilterViewModel.Header);
            }            
        }
        public void SetUserToListUserLeases(User user)
        {
            //Console.WriteLine("User in set: " + user.Name);
            ListUserLeasesViewModel listUserLeasesViewModel = new ListUserLeasesViewModel();
            listUserLeasesViewModel.User = user;
            
            if (!checkIfHeaderIsOpened(listUserLeasesViewModel.Header))
            {
                this.Contents.Add(listUserLeasesViewModel);
                addHeader(listUserLeasesViewModel.Header);
            }
            

        }

        private void addHeader(string headerName)
        {
            this.openedHeaders.Add(headerName);
        }
       private bool checkIfHeaderIsOpened(string headerName)
        {
            return this.openedHeaders.Contains(headerName);
            
        }
    }
}
