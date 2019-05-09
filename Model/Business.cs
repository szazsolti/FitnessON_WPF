using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessON.Model
{
    public class Business
    {
        FitnessDB _dbContext = null;
        public Business()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
             Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            _dbContext = new FitnessDB();
        }

        internal IEnumerable<User> Get()
        {
            return _dbContext.User.ToList();
        }

        internal void Delete(User person)
        {
            _dbContext.User.Remove(person);
        }

        internal void Update(User updatedPerson)
        {
            CheckValidations(updatedPerson);
            if (updatedPerson.Id > 0)
            {
                User selectedPerson = _dbContext.User.First(p => p.Id == updatedPerson.Id);
                //selectedPerson.FirstName = updatedPerson.FirstName;
                //selectedPerson.LastName = updatedPerson.LastName;
                //selectedPerson.CityOfResidence = updatedPerson.CityOfResidence;
                //selectedPerson.Profession = updatedPerson.Profession;
            }
            else
            {
                _dbContext.User.Add(updatedPerson);
            }

            _dbContext.SaveChanges();
        }

        private void CheckValidations(User person)
        {
            if(person == null)
            {
                throw new ArgumentNullException("Person", "Please select record from Grid or Add New");
            }
            /*
            if (string.IsNullOrEmpty(person.FirstName))
            {
                throw new ArgumentNullException("First Name", "Please enter FirstName");
            }
            else if (string.IsNullOrEmpty(person.LastName))
            {
                throw new ArgumentNullException("Last Name", "Please enter LastName");
            }
            else if ((int)person.Profession == -1)
            {
                throw new ArgumentNullException("Profession", "Please enter Profession");
            }*/
        }
    }
}
