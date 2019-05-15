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
            List<User> users = this.fitnessDB.User.ToList();
            List<Card> cards = GetCards();

            foreach (var item in users)
            {
                foreach (var itemCard in cards)
                {
                    if(item.Card_Id == itemCard.Id)
                    {
                        item.Card = itemCard;
                        break;
                    }
                }
            }

            return users;
        }


        public string GetCardNumber(int cardID)
        {
            return this.fitnessDB.Card.Where(c => c.Id == cardID).ToList().First().CardNumber;
        }

        public List<int> GetEntriesNumber()
        {
            List<int> entries = new List<int>();
            foreach (var item in this.fitnessDB.NumberOfEntriesLeases.ToList())
            {
                entries.Add(item.Quantity);
            }
            return entries;
        }

        public List<int> GetPeriodLeasesNumber()
        {
            List<int> days = new List<int>();
            foreach (var item in this.fitnessDB.PeriodLeases.ToList())
            {
                days.Add(item.NumberOfDays);
            }
            return days;
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
                        break; 
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
                        break;
                    }
                }
            }

            return mixLeases;
        }

        public List<MixLease> GetMixLeasesValidityFilter(int valid)
        {
            List<PeriodLease> periodLeases = GetPeriodLeases();
            List<NumberOfEntriesLease> numberOfEntries = GetNumberOfEntriesLeases();
            int id = this.fitnessDB.PeriodLeases.Where(vt => vt.NumberOfDays == valid).ToList().First().Id;
            List<MixLease> mixLeases = this.fitnessDB.MixLeases.Where(vt => vt.NumberOfEntriesLease_Id == id).ToList();

            foreach (var item in mixLeases)
            {
                foreach (var periodItem in periodLeases)
                {
                    if (item.PeriodLease_Id == periodItem.Id)
                    {
                        item.PeriodLease = periodItem;
                        break;
                    }
                }
            }

            foreach (var item in mixLeases)
            {
                foreach (var numberItem in numberOfEntries)
                {
                    if (item.NumberOfEntriesLease_Id == numberItem.Id && item.NumberOfEntriesLease.Quantity == valid)
                    {
                        item.NumberOfEntriesLease = numberItem;
                        break;
                    }
                }
            }
            Console.WriteLine(id + " " + mixLeases.Count);
            return mixLeases;
        }

        public List<MixLease> GetMixLeasesEntriesFilter(int entries)
        {
            List<PeriodLease> periodLeases = GetPeriodLeases();
            List<NumberOfEntriesLease> numberOfEntries = GetNumberOfEntriesLeases();
            int id = this.fitnessDB.NumberOfEntriesLeases.Where(vt => vt.Quantity == entries).ToList().First().Id;
            List<MixLease> mixLeases = this.fitnessDB.MixLeases.Where(vt => vt.NumberOfEntriesLease_Id == id).ToList();

            foreach (var item in mixLeases)
            {
                foreach (var periodItem in periodLeases)
                {
                    if (item.PeriodLease_Id == periodItem.Id)
                    {
                        item.PeriodLease = periodItem;
                        break;
                    }
                }
            }

            foreach (var item in mixLeases)
            {
                foreach (var numberItem in numberOfEntries)
                {
                    if (item.NumberOfEntriesLease_Id == numberItem.Id && item.NumberOfEntriesLease.Quantity == entries)
                    {
                        item.NumberOfEntriesLease = numberItem;
                        break;
                    }
                }
            }
            Console.WriteLine(id + " " + mixLeases.Count);
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
                        break;
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
                        break;
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

        public List<Logs> GetLogs()
        {
            return this.fitnessDB.Logs.ToList(); ;
        }

        public List<Logs> GetLogsWithUserFilter(string username)
        {
            return this.fitnessDB.Logs.Where(l => l.User.Name == username).ToList();
        }

        public List<Logs> GetLogsWithCardFilter(string cardNumber)
        {
            return this.fitnessDB.Logs.Where(l => l.User.Card.CardNumber == cardNumber).ToList();
        }

        public List<Logs> GetLogsWithTypeFilter(string type)
        {
            return this.fitnessDB.Logs.Include("User").Where(l => l.Lease.MixLease.Name == type).ToList();
        }

        public void InsertToLog(User user, Lease lease,string message)
        {
            Logs log = new Logs();
            List<Logs> logs = GetLogs();

            try
            {
                log.Log_Id = logs.Max().Log_Id + 1;
            }
            catch(Exception e)
            {
                log.Log_Id = 1;
            }

            log.Time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            log.User_Id = user.Id;
            log.User = user;
            log.Lease_Id = lease.Id;
            log.Lease = lease;
            log.Message = message;
            this.fitnessDB.Logs.Add(log);
            this.fitnessDB.SaveChanges();
        }

        public List<Lease> GetLeasesWithTypeFilter(string leaseName)
        {
            return this.fitnessDB.Leases.Where(vt => vt.MixLease.Name.Equals(leaseName)).ToList();
        }

        public List<Lease> GetInvalidLeases()
        {
            return this.fitnessDB.Leases.Where(vt => vt.NumberOfEntries == 0).ToList();
        }

        public List<Lease> GetLeasesWithStatusFilter(bool validity)
        {
            long currentTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            List<Lease> leases = new List<Lease>();
            if (validity)
            {
                foreach (var item in GetLeases())
                {
                    if(TimestringToTimestamps(item.EndValidity) > currentTime)
                    {
                        leases.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in GetLeases())
                {
                    if (TimestringToTimestamps(item.EndValidity) < currentTime)
                    {
                        leases.Add(item);
                    }
                }
            }
            return leases;
        }
        public long TimestringToTimestamps(string time){
            string[] dataParts = time.Replace('/', ' ').Replace('-', ' ').Replace(':', ' ').Replace('P', ' ').Replace('M', ' ').Replace('A', ' ').Split(' ');
            if (dataParts.Count()<4){return 0;}
            var toDate = new DateTime((Int32.Parse(dataParts[0])), (Int32.Parse(dataParts[1])), (Int32.Parse(dataParts[2])));
            toDate.AddDays((Int32.Parse(dataParts[3])));//ora
            toDate.AddDays((Int32.Parse(dataParts[4])));//perc
            return long.Parse(toDate.Subtract(new DateTime(1970, 01, 01)).TotalSeconds.ToString());
        }


        public List<Lease> GetLeases()
        {
            return this.fitnessDB.Leases.ToList();
        }

        public void UpdateLeaseNumberOfEntriesAsync(int numberOfEntries, int id, bool selected)
        {
            //Console.WriteLine("Berlet neve update: " + lease.Name);
            //await this.fitnessDB.Database.ExecuteSqlCommandAsync(@"Update [Leases] SET NumberOfEntries = {0} WHERE Id = {1}", new object[] { lease.NumberOfEntries, lease.Id });
            this.fitnessDB.Database.ExecuteSqlCommand(@"Update [Leases] SET NumberOfEntries = {0} WHERE Id = {1}", numberOfEntries, id);
            this.fitnessDB.Database.ExecuteSqlCommand(@"Update [Leases] SET inUse = {0} WHERE Id = {1}", selected, id);
            this.fitnessDB.SaveChanges();

        }

    }
}
