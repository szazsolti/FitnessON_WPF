
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
    //MainWindowViewModel:NotificationClass
    public class MainWindowViewModel : NotificationClass
    {
        public static Controller Controller;
        private ObservableCollection<IFitnessContent> contents;
        private IFitnessContent selectedContent;

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
        }

        public void SetUserToListUserLeases(User user)
        {
            ListUserLeasesViewModel listUserLeasesViewModel = new ListUserLeasesViewModel();
            listUserLeasesViewModel.User = user;
            this.Contents.Add(listUserLeasesViewModel);

        }

        /*
        Business _business;
        private User _person;
        public EventHandler ShowMessageBox = delegate { };
        public MainWindowViewModel()
        {          
            _business = new Business();
            PersonCollection = new ObservableCollection<User>(_business.Get());
        }

        private ObservableCollection<User> personCollection;
        public ObservableCollection<User> PersonCollection
        {
            get { return personCollection; }
            set { personCollection = value;
                OnProprtyChanged();
            }
        }
        public User SelectedPerson
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnProprtyChanged();
            }
        }


        public RelayCommand Add
        {
            get
            {
                return new RelayCommand(AddPerson, true);
            }        
        }

        private void AddPerson()
        {
            try
            {
                SelectedPerson = new User();                       
            }
            catch (Exception ex)
            {
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = ex.Message
                });
            }            
        }

        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(SavePerson, true);
            }
        }

        private void SavePerson()
        {
            try
            {
                _business.Update(SelectedPerson);
                PersonCollection = new ObservableCollection<User>(_business.Get());
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = "Changes are saved !"
                });
            }
            catch (Exception ex)
            {
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = ex.Message
                });
            }               
          
        }

        public RelayCommand Delete
        {
            get
            {
                return new RelayCommand(DeletePerson, true);
            }
        }

        private void DeletePerson()
        {
            _business.Delete(SelectedPerson);
        }
    }*/
    }
}
