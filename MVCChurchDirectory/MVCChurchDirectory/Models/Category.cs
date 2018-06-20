using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    [Table("tblCategory")]
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        [Required]
        [StringLength(255, MinimumLength =3)]
        public string Name { get; set; }
    }
}