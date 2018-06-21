using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.ViewModels
{
    public class AdminDropListModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }

    public class AdminViewModel
    {
        public List<AdminDropListModel> AdminList { get; set; }
        public int SelectedID { get; set; }
    }
}