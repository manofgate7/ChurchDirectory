using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCChurchDirectory.Repos
{
    public interface IKid
    {
        List<Child> GetChildren();
        List<Child> GetChildren(int personID);
        bool UpdateChild(Child child);
        bool AddNewChild(Child child);
        Child GetChild(int childID);
    }
}
