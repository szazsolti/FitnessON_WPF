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
        /*
        public List<Lease> GetUserLeases(string card_Id)
        {
            return this.fitnessDB.Leases.Include("IntermediateLease").Where(a => a.Id == card_Id).ToList() ?? new List<Lease>();
        }
        */
    }
}
