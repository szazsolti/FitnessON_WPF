using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Logic;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessON.ViewModel
{
    public class LoginScreenViewModel:NotificationClass, ILoginContent
    {
        private List<User> users;
        private String card_Id;

        public LoginScreenViewModel()
        {
            this.users = Data.Controller.GetUsers();
            this.VerifyLoginCommand = new RelayCommand(this.VerifyLoginCommandExecute, this.VerifyLoginCommandCanExecute);
            Console.WriteLine(users.ToList().First().Name);
            
        }

        public List<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
                this.OnProprtyChanged();
            }
        }

        public String Card_Id
        {
            get
            {
                return this.card_Id;
            }
            set
            {
                this.card_Id = value;
                this.OnProprtyChanged();
            }
        }

        public RelayCommand VerifyLoginCommand
        {
            get;
            set;
        }

        public string Header => "Login";

        public void VerifyLoginCommandExecute()
        {
            bool found = false;
            foreach (var item in users)
            {
                if (item.Card_Id.Equals(this.card_Id))
                {
                    found = true;
                    Console.WriteLine("found"); 
                }
            }
            if (!found)
            {
            System.Windows.MessageBox.Show("Az ön által megadott kártyaszám érvénytelen!", "Hiba történt!");
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VerifyLoginCommandExecute();
            }
        }
        public bool VerifyLoginCommandCanExecute()
        {
           if(this.card_Id != null && this.card_Id.Length > 0)
            {
                return true;
            }
            return false;

        }

    }
}
