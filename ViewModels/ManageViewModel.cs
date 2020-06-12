using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForHealing.ViewModels
{
    public class ManageViewModel
    {
        public IEnumerable<ProjectForHealing.Models.Resource> resources { get; set; }
        public IEnumerable<ProjectForHealing.Models.UnassocResource> unassocResources { get; set; }

    }
}
