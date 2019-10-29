using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class AddResourceViewModel
    {
       [Required]
       [Display(Name ="Organization Name")]
        public string OrgName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters exactly")]
        public string OrgNumber { get; set; }
        public string OrgEmail { get; set; }
        public string OrgAddress { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "This field must be 5 characters exactly")]
        public string OrgZip { get; set; }
       
        [StringLength(10, ErrorMessage = "Number must not exceed 10 characters")]
        public string OrgSte { get; set; }
        public string OrgDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public bool? IsApproved { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters exactly")]
        public string RepNumber { get; set; }
        public string RepEmail { get; set; }
    }
}
