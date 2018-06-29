using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCChurchDirectory.ViewModels
{
    public class EditPersonViewModel
    {
        [HiddenInput]
        public int personID { get; set; }

        [DisplayName("Last Name")]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        [StringLength(255)]
        public string Address { get; set; }

        [DisplayName("City, state Zip")]
        [StringLength(255)]
        public string CityStateZip { get; set; }

        [DisplayName("Best Way To Be Contacted")]
        [StringLength(255)]
        public string BestWayToContact { get; set; }

        [DisplayName("Do you have any Kids?")]
        public bool? HaveKids { get; set; }

        [DisplayName("What is your Material status?")]
        [Range(0, 5)]
        public int? MatStatus { get; set; }

        [Timestamp]
        public DateTime Modified { get; set; }

        [HiddenInput]
        public int CategoryID { get; set; }

        [DisplayName("Church Job")]
        public string Category { get; set; }

        [DisplayName("Kid(s):")]
        public virtual ICollection<Child> Children { get; set; }

        public HttpPostedFileBase Picture { get; set; }

        public int? MarriedTo { get; set; }

        public List<PersonNameViewModel> people { get; set; }

        public List<Category> Categories { get; set; }

        public List<MaritalVModel> MartialStatuses { get; set; }

        public IDictionary<bool, string> YNOptions { get; set; }

        public byte[] PostedImage { get; set; }


        public static EditPersonViewModel Map(Person dm)
        {
            return new EditPersonViewModel()
            {
                personID = dm.ID
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
                , MarriedTo = dm.PersonMarriedTo
                , PostedImage = dm.Image
            };
        }
    }
}