using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    public class Category
    {
        [Key]
        public int CatID;

        [Required]
        [StringLength(255, MinimumLength =3)]
        public string Name;
    }
}