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
            try
            {
                dtb.Children.Add(child);
                dtb.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool AddNewPerson(Person person)
        {
            try
            {
                person.Modified = DateTime.Now;
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
            List<Child> children = new List<Child>();
            children = dtb.Children.ToList();
            return children;
        }

        public List<Child> GetChildren(int personID)
        {
            List<Child> children = new List<Child>();
            children = dtb.Children.Where(x=> x.PersonID == personID).ToList();
            return children;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people = dtb.Persons.ToList();
            return people;
            
        }

        public Person GetPerson(int ID)
        {
            if (ID != -1)
            {
                Person person = dtb.Persons.Single(m => m.ID == ID);

                return person;
            }
            else
            {
                return null;
            }
                
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
            try
            {
                Child uChild = dtb.Children.Single(m => m.ChildID == child.ChildID);
                uChild.Age = child.Age;
                uChild.FirstName = child.FirstName;
                uChild.LastName = child.LastName;
                uChild.PersonID = child.PersonID;
                dtb.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }
            return true;
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
                uPerson.PersonMarriedTo = person.PersonMarriedTo;
                dtb.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}