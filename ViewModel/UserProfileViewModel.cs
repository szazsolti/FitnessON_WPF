﻿using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    public class UserProfileViewModel : NotificationClass, IProfileContent
    {
        private User loggedInUser;

        public UserProfileViewModel()
        {

        }

        public User User
        {
            get
            {
                return this.loggedInUser;
            }
            set
            {
                this.loggedInUser = value;
                this.OnProprtyChanged();
            }
        }

        public string UserName
        {
            get
            {
                return this.loggedInUser.Name;
            }
            
        }

        public string EmailAddress
        {
            get
            {
                return this.loggedInUser.Email;
            }

        }

        public string PhoneNumber
        {
            get
            {
                return this.loggedInUser.Phone;
            }

        }

        public string CardNumber
        {
            get
            {
                return this.loggedInUser.Card_Id;
            }

        }

        public string ProfilePicture
        {
            get
            {
                return this.loggedInUser.Picture;
            }

        }

        public string Header => "Saját profilom";
    }
}
