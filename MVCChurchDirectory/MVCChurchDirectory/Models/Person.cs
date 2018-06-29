using MVCChurchDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCChurchDirectory.Models
{
    [Table("tblPerson")]
    public class Person
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength =3)]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string CityStateZip { get; set; }

        [StringLength(255)]
        public string BestWayToContact { get; set; }

        public bool? HaveKids { get; set; }

        [Range(0, 5)]
        public int? MatStatus { get; set; }

        public int? PersonMarriedTo { get; set; }


        
        public DateTime Modified { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        
        public virtual Category Category { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }


        public static Person Map(EditPersonViewModel dm)
        {
            return new Person()
            {
                ID = dm.personID
                ,
                Address = dm.Address
                ,
                BestWayToContact = dm.BestWayToContact
                ,
                CategoryID = dm.CategoryID
                ,
                CityStateZip = dm.CityStateZip
                ,
                Email = dm.Email
                ,
                FirstName = dm.FirstName
                ,
                HaveKids = dm.HaveKids
                ,
                LastName = dm.LastName
                ,
                MatStatus = dm.MatStatus
                ,
                Modified = dm.Modified
                ,
                PhoneNumber = dm.PhoneNumber
                ,
                Picture = dm.Picture
                , PersonMarriedTo = dm.MarriedTo
            };
        }
    }
}