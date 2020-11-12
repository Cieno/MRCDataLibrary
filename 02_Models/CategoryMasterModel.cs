using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MRCDataLibrary._02_Models
{
    public class CategoryMasterModel
    {
        //[MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        //[MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an order name")]
        //[Range(1, int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        //[Range(1, 10, ErrorMessage = "You can select up to 10 meals")]
        [Required]
        [DisplayName("Category ID")]
        public string CATEGORY_ID { get; set; }

        [Required]
        [DisplayName("Category Description")]
        public string CATEGORY_DESCR { get; set; }

        [DisplayName("Active Y/N")]
        public bool ACTIVE_YN { get; set; }

        [Required]
        [DisplayName("Abbreviation")]
        //[Range(2, 2, ErrorMessage = "The abbreviation is supposed to be 2 upper case characters.")]
        [MaxLength(2, ErrorMessage = "The abbreviation is supposed to be 2 upper case characters.")]
        [MinLength(2, ErrorMessage = "The abbreviation is supposed to be 2 upper case characters.")]
        public string ABBR_CD { get; set; }

        [DisplayName("Create Date Time")]
        public DateTime CREATE_DT  { get; set; }
    }
}
