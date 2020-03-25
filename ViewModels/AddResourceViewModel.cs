using Microsoft.AspNetCore.Http;
using ProjectForHealing.Models;
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
        [Display(Name = "Organization's Name")]
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
        [Display(Name = "Zip Code")]
        public string OrgZip { get; set; }

        [StringLength(10, ErrorMessage = "Number must not exceed 10 characters")]
        [Display(Name = "Suite #")]
        public string OrgSte { get; set; }
        [Required]
        [Display(Name = "Description of service(s) provided")]
        public string OrgDescription { get; set; }
        [Required]
        [Display(Name = "Organization's Link")]
        public string WebsiteUrl { get; set; }
        [Required]
        [Display(Name = "City")]
        public string OrgCity { get; set; }
        [Required]
        public string[] ResourceTypes { get; set; }
      //  public ResourceType RType1 { get; set; }
       // public ResourceType RType2 { get; set; }
       // public ResourceType RType3 { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
