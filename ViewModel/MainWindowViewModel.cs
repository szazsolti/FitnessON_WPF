
namespace FitnessON.ViewModel
{
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


        public MainWindowViewModel()
        {
            Instance = this;
            Controller = new Controller();
        }

        public static MainWindowViewModel Instance { get; private set; }
        public EventHandler ShowMessageBox = delegate { };
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
