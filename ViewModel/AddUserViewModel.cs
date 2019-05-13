using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
            if (ValidateData())
            {
                //Console.WriteLine(userName + " " + phoneNumber + " " + emailAddress + " " + cardNumber);
                User user = new User();
                user.Name = userName;
                user.Phone = phoneNumber;
                user.Email = emailAddress;
                user.Card_Id = cardNumber;
                user.Picture = imagePath;
                ClearData();
            } 

        }

        private bool ValidateData()
        {
            string message = "";
            if( userName == null || userName.ToString().Length == 0 ||
                emailAddress == null || emailAddress.ToString().Length == 0 || 
                cardNumber == null || cardNumber.ToString().Length == 0){
                message += "-Minden mezőt ki kell tölteni!\n";
            }
           if(phoneNumber == null || phoneNumber.Length > 12 || phoneNumber.Length <= 10 )
            {
                message += "-Érvénytelen telefonszám!\n";
            }
            if (emailAddress == null || !IsValidEmail(emailAddress))
            {
                message += "-Érvénytelen emailcím!\n";
            }
            if(userName == null || userName.Length < 3)
            {
                message += "-Túl rövid a felhasználónév!\n";
            }
            if (message.Length != 0)
            {
                System.Windows.MessageBox.Show(message, "Helytelen adatok!");
                return false;
            }
            return true;
        }

       

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
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

        private void ClearData()
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
                if(value.ToString().Length == 0 )
                {
                    this.phoneNumber = value;
                }
                else if ("0123456789".Contains(value.ToString().Last()))
                {
                    this.phoneNumber = value;
                }
                else if( value.ToString().Length == 1 && value.ToString().First().Equals('+'))
                {
                    this.phoneNumber = value;
                }
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
