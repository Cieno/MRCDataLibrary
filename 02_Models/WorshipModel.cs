using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MRCDataLibrary._02_Models
{
    public class WorshipModel
    {
        [DisplayName("Worship ID")]
        public string WorshipId { get; set; }
        [Required]
        [DisplayName("Worship Date")]
        public DateTime WorshipDate { get; set; } = DateTime.UtcNow.Date;
        [Required]
        [DisplayName("Worship Type")]
        public string WorshipType { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Worship Name")]
        public string WorshipName { get; set; }
        [DisplayName("Worship Type Select")]
        public List<SelectListItem> WorshipTypeSelectList { get; set; } = new List<SelectListItem>();
        public string SimpleDate { get; set; }
        public string SimpleTime { get; set; }

        public bool IsDuplicate { get; set; }
    }
}
