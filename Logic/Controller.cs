namespace FitnessON.Logic
{
    using FitnessON.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Controller
    {
        private FitnessDB fitnessDB;

        public Controller()
        {
            this.fitnessDB = new FitnessDB();
        }

        public List<User> GetUsers()
        {
            return this.fitnessDB.User.ToList();
        }


        public string GetCardNumber(int cardID)
        {
            return this.fitnessDB.Card.Where(c => c.Id == cardID).ToList().First().CardNumber;
        }

        public List<Card> GetCards()
        {
            return this.fitnessDB.Card.ToList();
        }

        public List<PeriodLease> GetPeriodLeases()
        {
            return this.fitnessDB.PeriodLeases.ToList();
        }

        public List<NumberOfEntriesLease> GetNumberOfEntriesLeases()
        {
            return this.fitnessDB.NumberOfEntriesLeases.ToList();
        }

        public List<MixLease> GetMixLeases()
        {
            List<MixLease> mixLeases = this.fitnessDB.MixLeases.ToList();
            List<PeriodLease> periodLeases = GetPeriodLeases();
            List<NumberOfEntriesLease> numberOfEntries = GetNumberOfEntriesLeases();

            foreach (var item in mixLeases)
            {
                foreach (var periodItem in periodLeases)
                {
                    if(item.PeriodLease_Id == periodItem.Id)
                    {
                        item.PeriodLease = periodItem;
                        continue; 
                    }
                }
            }

            foreach (var item in mixLeases)
            {
                foreach (var numberItem in numberOfEntries)
                {
                    if(item.NumberOfEntriesLease_Id == numberItem.Id)
                    {
                        item.NumberOfEntriesLease = numberItem;
                        continue;
                    }
                }
            }

            return mixLeases;
        }


        public List<Lease> GetUserLeases(int card_Id)
        {
            List<Lease> leases =  this.fitnessDB.Leases.Where(lease => lease.Card_Id == card_Id).OrderBy(m=> m.MixLease.Price).ToList();
            List<MixLease> mixLeases = GetMixLeases();
            List<Card> cards = GetCards();

            foreach (var item in leases)
            {
                foreach (var mixItem in mixLeases)
                {
                    if(item.MixLeases_Id == mixItem.Id)
                    {
                        item.MixLease = mixItem;
                        continue;
                    }
                }
            }

            foreach (var item in leases)
            {
                foreach (var itemCard in cards)
                {
                    if(item.Card_Id == itemCard.Id)
                    {
                        item.Card = itemCard;
                        continue;
                    }
                }
            }

            return leases;
        }

        public void InsertUser(User user, Card card)
        {
            //string insertCard = "INSERT INTO Card(Id, CardNumber) values("+card.Id + ", " +card.CardNumber + ")";
            //string insertUser = "INSERT INTO User(Id, Name, Phone, Email, Card_Id, Picture, Permission) values("+user.Id + ", " +user.Name + ", " + user.Phone + ", " + user.Email + ", " + +user.Card_Id + ", " +user.Picture + ", " + user.Permission + ")";
            this.fitnessDB.Card.Add(card);
            this.fitnessDB.User.Add(user);
            this.fitnessDB.SaveChanges();
        }

    }
}
