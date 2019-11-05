using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectForHealing.Models;

namespace ProjectForHealing.Controllers
{

    
    public class HomeController : Controller
    {
        private CRMSContext context;

        //asking to get instance of CRMS context
        public HomeController(CRMSContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        [Route("/Home/Index")]
        public IActionResult Search(string search) {
            List<Resource> resources = context.Resource.ToList();
           
       
          
           // ViewBag.Title =  search;

           
            return View(resources.Where(x => x.OrgName.Contains(search)));      
       }

       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
   
    }
}
