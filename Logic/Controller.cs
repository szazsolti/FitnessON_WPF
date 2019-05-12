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
            //Console.WriteLine(GetUserLeases("gazsi").First().StartValidity);
            return this.fitnessDB.User.ToList();
        }

        public List<Lease> GetUserLeases(string card_Id)
        {
            //this.fitnessDB.Leases.Include("IntermediateLease").Where(a => a.Id == card_Id).ToList() ?? new List<Lease>();
            List<IntermediateLease> il = this.fitnessDB.IntermediateLeases.Include("Lease").Where(vt => vt.Card_Id == card_Id).ToList();
            List<Lease> l = new List<Lease>();
            foreach (var item in il)
            {
                l.Add(item.Lease);
            }
            foreach (var item in l)
            {
                if(item != null)
                {
                    Console.WriteLine(item.ToString());
                }
                else
                {
                    Console.WriteLine("Olyan null hogy csak na");
                }
                    
            }
            
            return l;
        }

    }
}
