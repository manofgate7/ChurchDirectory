using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    public class Child
    {
        [Key]
        public int ChildID;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName;

        public int? Age;

        
        public int PersonID;

        [ForeignKey("PersonID")]
        public Person Person;
    }
}