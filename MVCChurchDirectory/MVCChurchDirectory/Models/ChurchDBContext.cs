using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    public class ChurchDBContext : DbContext
    {
        public ChurchDBContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Child> Children { get; set; }



    }
}