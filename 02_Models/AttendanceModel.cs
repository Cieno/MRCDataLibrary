using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MRCDataLibrary._02_Models
{
    public class AttendanceModel
    {
        [Required]
        [DisplayName("Worship ID")]
        public string WorshipId { get; set; }
        [DisplayName("Worship Date")]
        public DateTime WorshipDate { get; set; }
        [DisplayName("Worship Name")]
        public string WorshipName { get; set; }
        [Required]
        [DisplayName("Member ID")]
        public string MemberId { get; set; }
        [DisplayName("Member Name")]
        public string MemberName { get; set; }
        [DisplayName("Member Select")]
        public List<SelectListItem> MemberList { get; set; } = new List<SelectListItem>();
        [DisplayName("Check-In Time")]
        public DateTime RegisterDt { get; set; }

        [Required]
        [DisplayName("Attendance Type")]
        public string AttendanceType { get; set; }
        public TimeSpan EstimatedArrival { get; set; }
        public bool SignAgreement { get; set; }
        [Required]
        public string Initial { get; set; }
        public string Descr { get; set; }

        //public Image SIGN_IMG { get; set; }
    }
}
