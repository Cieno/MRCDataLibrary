using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MRCDataLibrary._02_Models
{
    public class CodeMasterModel
    {
        //[MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        //[MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an order name")]
        //[Range(1, int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        //[Range(1, 10, ErrorMessage = "You can select up to 10 meals")]

        [DisplayName("Code ID")]
        public string CODE_ID { get; set; }
        [DisplayName("Category ID")]
        public string CATEGORY_ID { get; set; }
        [DisplayName("Code Description")]
        public string CODE_DESCR { get; set; }
        [DisplayName("Sort Order")]
        public int SORT_ORDER { get; set; }
        [DisplayName("Activie Y/N")]
        public bool ACTIVE_YN { get; set; }
        [DisplayName("Create Date Time")]
        public DateTime CREATE_DT { get; set; }
        [DisplayName("Category Select")]
        public string CATEGORY_DESCR { get; set; }
        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

    }
}
