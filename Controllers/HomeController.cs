using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectForHealing.Models;
using ProjectForHealing.ViewModels;

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
           // List<Resource> resources = context.Resource.ToList();

           // List<Resource> zips = resources.Where(x => x.OrgZip == zip).ToList();
            var sources = context.Resource.Where(x => x.OrgName.Contains(search)
                                            && x.OrgZip == "32207" /* todo: unhard code */).ToList();

          ViewBag.Title =  search;


            return View(sources);      
       }

       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

       [HttpGet] 
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // todo: check for login
            HttpContext.Session.Set("username", Encoding.UTF8.GetBytes(model.Email));

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult EditorLogin()
        {
            return View();
        }

   
   
    }
}
