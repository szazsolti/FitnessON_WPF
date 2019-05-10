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
    public class LoginScreenViewModel:NotificationClass, ILoginContent
    {
        private List<User> users;
        private String card_Id;

        public LoginScreenViewModel()
        {
            this.users = Data.Controller.GetUsers();
            this.VerifyLoginCommand = new RelayCommand(this.VerifyLoginCommandExecute, this.VerifyLoginCommandCanExecute);
            //Console.WriteLine(users.ToList().Count);
            
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

        }

        public bool VerifyLoginCommandCanExecute()
        {
            return this.card_Id != null;
        }

    }
}