using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectForHealing.Models
{
    public partial class Resource
    {
        [Key]
        public int ResourceID { get; set; }
        public string OrgName { get; set; }
        public string OrgNumber { get; set; }
        public string OrgEmail { get; set; }
        public string OrgAddress { get; set; }
        public string OrgCity { get; set; }
        public string OrgZip { get; set; }
        public string OrgSte { get; set; }
        public string OrgDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsApproved { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string RepNumber { get; set; }
        public string RepEmail { get; set; }
        public string PhotoPath { get; set; }
        public Resource()
        {
           
            IsApproved = false;
        }
    }
}
