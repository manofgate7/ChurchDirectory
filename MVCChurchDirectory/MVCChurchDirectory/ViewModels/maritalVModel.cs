using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.ViewModels
{
    public class MaritalVModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public MaritalVModel(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}