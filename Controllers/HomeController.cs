using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Search(string search, string zip) {
     
            var sources = context.Resource.Where(x => x.OrgName.Contains(search)
                                            && x.OrgZip == zip).ToList();

            ViewBag.Org =  search;
            ViewBag.Zip = zip;


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
        public IActionResult Login(Admin adminP)
        {
            // todo: check for login
            var admin = context.Admin.SingleOrDefault(x => x.UserName == adminP.UserName && x.AdminPassWord == adminP.AdminPassWord);

            if (admin == null)
            {
                ViewBag.Message = "Incorrect UserName or Password";
                return View();
            }
            else
            {
                
                HttpContext.Session.Set("username", Encoding.UTF8.GetBytes(admin.UserName));
                HttpContext.Session.SetString("fname", admin.Fname);
                HttpContext.Session.SetString("lname", admin.Lname);
                HttpContext.Session.SetString("email", admin.Email);
                HttpContext.Session.SetString("pnumber", admin.Pnumber);
                if (admin.SuperUser == true)
                {
                    HttpContext.Session.SetString("role", "Master Admin");
                }
                else
                {
                    HttpContext.Session.SetString("role", "Staff");
                }


                return Redirect("/Admin/Index");
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Login");
        }

   
   
    }
}
