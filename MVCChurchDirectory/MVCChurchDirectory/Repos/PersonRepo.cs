using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCChurchDirectory.Models;

namespace MVCChurchDirectory.Repos
{
    public class PersonRepo : IPerson, IKid
    {
        static string connString = "Data Source=(LocalDB)\\v12.0; " +
            "Integrated Security=SSPI;" +
            "AttachDbFileName=|DataDirectory|\\ChurchDir.MDF;";
        private ChurchDBContext dtb = new ChurchDBContext(connString);

        public bool AddNewChild(Child child)
        {
            throw new NotImplementedException();
        }

        public bool AddNewPerson(Person person)
        {
            try
            {
                dtb.Persons.Add(person);
                dtb.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public List<Child> GetChildren()
        {
            throw new NotImplementedException();
        }

        public List<Child> GetChildren(int personID)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people = dtb.Persons.ToList();
            return people;
            
        }

        public Person GetPerson(int ID)
        {
            Person person = dtb.Persons.Single(m => m.ID == ID);
            return person;
        }

        public List<Person> GetSearchedPeople(string name)
        {
            List<Person> people = new List<Person>();
            people = dtb.Persons.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name) || x.FirstName + " " +  x.LastName == name).ToList();
            return people;
        }

        public List<Person> GetSearchedPeople(int category)
        {
            List<Person> people = new List<Person>();
            people = dtb.Persons.Where(x => x.CategoryID == category).ToList();
            return people;
        }

        public bool UpdateChild(Child child)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person person)
        {
            try
            {
                Person uPerson = dtb.Persons.Single(m => m.ID == person.ID);
                uPerson.LastName = person.LastName;
                uPerson.FirstName = person.FirstName;
                uPerson.Address = person.Address;
                uPerson.BestWayToContact = person.BestWayToContact;
                uPerson.CategoryID = person.CategoryID;
                uPerson.CityStateZip = person.CityStateZip;
                uPerson.Email = person.Email;
                uPerson.HaveKids = person.HaveKids;
                uPerson.MatStatus = person.MatStatus;
                uPerson.PhoneNumber = person.PhoneNumber;
                uPerson.Picture = person.Picture;
                uPerson.Modified = DateTime.Now;
                dtb.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}