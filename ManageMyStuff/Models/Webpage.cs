using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageMyStuff.Models
{
    public class Webpage
    {

        public int WebPageID { get; set; }

        [StringLength(50)]
        [Required]
        public string Category { get; set; }


        [Display(Name = "URL Address")]
        [Required]
        public string WebAddress { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Web Page Description")]
        public string WebAddressDescription { get; set; }


        [Display(Name = "URL Address Extra")]
        public string WebAddressExtra { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Web Page Extra - Description")]
        public string WebAddressExtraDescription { get; set; }


    }
}