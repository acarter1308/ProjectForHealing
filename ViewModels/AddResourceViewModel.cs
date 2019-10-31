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
       [Display(Name ="Organization's Name")]
        public string OrgName { get; set; }
        [Required]
        [Display(Name = "Organization's Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters exactly")]
        public string OrgNumber { get; set; }

        [Required]
        [Display(Name = "Organization's Email Address")]
        public string OrgEmail { get; set; }
        [Required]
        [Display(Name = "Organization's Street Address")]
        public string OrgAddress { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "This field must be 5 characters exactly")]
        [Display(Name = "Organization's Zip Code")]
        public string OrgZip { get; set; }
       
        [StringLength(10, ErrorMessage = "Number must not exceed 10 characters")]
        public string OrgSte { get; set; }
        [Required]
        [Display(Name = "Service(s) Your Organization Provides")]
        public string OrgDescription { get; set; }
        [Required]
        [Display(Name = "Organization's Link")]
        public string WebsiteUrl { get; set; }
        public bool? IsApproved { get; set; }
        [Required]
        [Display(Name = "Your First Name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Your Last Name")]
        public string Lname { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters exactly")]
        [Display(Name = "Contact Number")]
        public string RepNumber { get; set; }
        [Required]
        [Display(Name = "Contact Email")]
        public string RepEmail { get; set; }
    }
}
