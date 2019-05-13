using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.ViewModel
{
    public class AddUserViewModel : NotificationClass, IAddUserContent
    {
        public string Header => "Felhasználó létrehozás";
        private string imagePath = "https://i.ibb.co/94bn6zr/adduser.png";
        private string userName;
        private string emailAddress;
        private string phoneNumber;
        private string cardNumber;

        public AddUserViewModel()
        {
            this.AddImage = new RelayCommand(this.OpenImageSelector);
            this.CreateUser = new RelayCommand(this.CreateUserProfile);
        }
        public RelayCommand AddImage { get; set; }

        public RelayCommand CreateUser { get; set; }
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
            set
            {
                this.imagePath = value;
                this.OnProprtyChanged();
            }
        }

        public void CreateUserProfile()
        {
            //System.Windows.MessageBox.Show("Semmi sincs megadva, mert semmi sincs megírva....", "Nincs semmi baj");
            Console.WriteLine(userName + " " + phoneNumber + " " + emailAddress + " " + cardNumber);
            User user= new User();
            user.Name = userName;
            user.Phone = phoneNumber;
            user.Email = emailAddress;
            user.Card_Id = cardNumber;
            user.Picture = imagePath;
            clearData();

        }
        public void OpenImageSelector()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
            }
        }

        private void clearData()
        {
            UserName = "";
            PhoneNumber = "";
            EmailAddress = "";
            CardNumber = "";
            ImagePath = "https://i.ibb.co/94bn6zr/adduser.png";
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
                this.OnProprtyChanged();
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
                this.OnProprtyChanged();
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                this.emailAddress = value;
                this.OnProprtyChanged();
            }
        }

        public string CardNumber
        {
            get
            {
                return this.cardNumber;
            }
            set
            {
                this.cardNumber = value;
                this.OnProprtyChanged();
            }
        }

    }


}
