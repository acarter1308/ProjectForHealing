﻿using System;
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
        public string RType1 { get; set; }
        public string RType2 { get; set; }
        public string RType3 { get; set; }
        public string PhotoPath { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public bool Tag1 { get; set; }
        public bool Tag2 { get; set; }
        public bool Tag3 { get; set; }
        public bool Tag4 { get; set; }
        public bool Tag5 { get; set; }
        public Resource()
        {
           
            IsApproved = false;
        }
    }
}
