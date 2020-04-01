using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class EducationViewModel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string Description { get; set; }
     
        public IFormFile PhotoPath { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
