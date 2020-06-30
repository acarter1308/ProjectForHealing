using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    
        public string Pnumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string AdminPassWord { get; set; }
        [Required]
        public bool isAdmin { get; set; }
            }
}
