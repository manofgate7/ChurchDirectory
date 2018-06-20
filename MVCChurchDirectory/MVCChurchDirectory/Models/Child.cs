using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    [Table("tblChild")]
    public class Child
    {
        [Key]
        public int ChildID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [ForeignKey("Person")]
        public int PersonID;

        
        public virtual Person Person { get; set; }
    }
}