using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCChurchDirectory.Repos
{
    public interface IPerson
    {
        List<Person> GetPeople();
        List<Person> GetSearchedPeople(string name);
        List<Person> GetSearchedPeople(int category);
        Person GetPerson(int ID);
        bool UpdatePerson(Person person);
        bool AddNewPerson(Person person);
    }
}
