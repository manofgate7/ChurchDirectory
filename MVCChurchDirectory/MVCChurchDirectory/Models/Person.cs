using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    public class Person
    {
        [Key]
        public int ID;
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName;

        [Required]
        [StringLength(100, MinimumLength =3)]
        public string LastName;

        [EmailAddress]
        [Required]
        public string Email;

        [Phone]
        [Required]
        public string PhoneNumber;

        [StringLength(255)]
        public string Address;

        [StringLength(255)]
        public string CityStateZip;

        [StringLength(255)]
        public string BestWayToContact;

        public bool? HaveKids;

        [Range(0, 5)]
        public int? MatStatus;

        public int? PersonMarriedTo;

        [Timestamp]
        public DateTime Modified;

        public int CategoryID;

        [ForeignKey("CategoryID")]
        public Category Category;

        public virtual ICollection<Child> Children { get; set; }

        public HttpPostedFileBase Picture;
    }
}