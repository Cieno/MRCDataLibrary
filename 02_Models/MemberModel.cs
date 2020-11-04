using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MRCDataLibrary._02_Models
{
    public class MemberModel
    {
        [DisplayName("Member ID")]
        public string MemberId { get; set; }
        [DisplayName("Register Date")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string EmailAddr { get; set; }
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);
        [DisplayName("Phone")]
        public string PhoneNum { get; set; }
        //public Image PHOTO_IMG { get; set; }
        //public Image SIGN_IMG { get; set; }
        [DisplayName("Family")]
        public string FamilyId { get; set; }
        [DisplayName("Group")]
        public string GroupCd { get; set; }
        [DisplayName("Team")]
        public string TeamCd { get; set; }
        [DisplayName("Group Name")]
        public string GroupName { get; set; }
        [DisplayName("Team Name")]
        public string TeamName { get; set; }
        [DisplayName("Group Select")]
        public List<SelectListItem> GroupSelectList { get; set; } = new List<SelectListItem>();
        [DisplayName("Team Select")]
        public List<SelectListItem> TeamSelectList { get; set; } = new List<SelectListItem>();

    }
}
