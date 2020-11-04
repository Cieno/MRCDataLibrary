using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRCDataLibrary._02_Models
{
    public class UserModel : IdentityUser
    {

        //[DisplayName("User ID")]
        //public string Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [DisplayName("User Role")]
        public string RoleId { get; set; }
        [DisplayName("User Role")]
        public string RoleName { get; set; }
        public List<SelectListItem> RoleSelectList { get; set; } = new List<SelectListItem>();

        //[DisplayName("Birth Date")]
        //public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        //[DisplayName("Family")]
        //public string FamilyId { get; set; }
        //[DisplayName("Group")]
        //public string GroupCd { get; set; }
        //[DisplayName("Team")]
        //public string TeamCd { get; set; }

        ////public Image PHOTO_IMG { get; set; }
        ////public Image SIGN_IMG { get; set; }


        //[DisplayName("Group Name")]
        //public string GroupName { get; set; }
        //[DisplayName("Team Name")]
        //public string TeamName { get; set; }
        //[DisplayName("Group Select")]
        //public List<SelectListItem> GroupSelectList { get; set; } = new List<SelectListItem>();
        //[DisplayName("Team Select")]
        //public List<SelectListItem> TeamSelectList { get; set; } = new List<SelectListItem>();
    }
}
