using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.ViewModels
{
    public class PersonNameViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static PersonNameViewModel Map(Person dm)
        {
            return new PersonNameViewModel()
            {
                ID = dm.ID
                , Name = dm.FirstName + " " + dm.LastName
            };
        }
    }
}