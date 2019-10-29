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
        public string OrgZip { get; set; }
        public string OrgSte { get; set; }
        public string OrgDescription { get; set; }
        public string WebsiteUrl { get; set; }
        public bool IsApproved { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string RepNumber { get; set; }
        public string RepEmail { get; set; }
      

      
/*
        public Resource(int resourceId, string orgName, string orgNumber, string orgEmail, string orgAddress, string orgCity, string orgZip, string orgSte, string orgDescription, string websiteUrl, bool? isApproved, string fname, string lname, string repNumber, string repEmail)
        {
            ResourceId = resourceId;
            OrgName = orgName;
            OrgNumber = orgNumber;
            OrgEmail = orgEmail;
            OrgAddress = orgAddress;
            OrgCity = orgCity;
            OrgZip = orgZip;
            OrgSte = orgSte;
            OrgDescription = orgDescription;
            WebsiteUrl = websiteUrl;
            IsApproved = isApproved;
            Fname = fname;
            Lname = lname;
            RepNumber = repNumber;
            RepEmail = repEmail;
        }
        */
        public Resource()
        {
           
            IsApproved = false;
        }
    }
}
