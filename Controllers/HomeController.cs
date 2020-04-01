using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(CRMSContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            context = dbContext;
        }

        public IActionResult Index()
        {
            var sources = context.Resource.Where(x =>  x.IsApproved == true).ToList();
            
            return View(sources);
        }

        [HttpPost]
        public IActionResult Search(string search, string zip) {

            if (zip == null)
            {
                var sources = context.Resource.Where(x => x.OrgName.Contains(search)&& x.IsApproved == true).ToList();
                ViewBag.Org = search;
                ViewBag.Zip = zip;
                return View(sources);
            }
            else
            {
                var sources = context.Resource.Where(x => x.OrgName.Contains(search)
                                            && x.OrgZip == zip && x.IsApproved == true).ToList();
                ViewBag.Org = search;
                ViewBag.Zip = zip;
                return View(sources);
            }
            

               
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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // todo: check for login
            var admin = context.Admin.SingleOrDefault(x => x.UserName == model.UserName && x.AdminPassWord == model.AdminPassWord);

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

                if(admin.PhotoPath != null)
                {
                    HttpContext.Session.SetString("pic", admin.PhotoPath);
                }
                else
                {
                    HttpContext.Session.SetString("pic", "null");
                }

                return Redirect("/Admin/Index");
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Login");
        }

        [HttpGet]
        public IActionResult ViewSource(int id)
        {
            var source = context.Resource.SingleOrDefault(x => x.ResourceID == id);
            return View(source);
        }


        [HttpGet]
        public IActionResult OpenFile(string path)
        {
            string PDFpath = "wwwroot/EducationFiles/"+ path;
            byte[] abc = System.IO.File.ReadAllBytes(PDFpath);
            System.IO.File.WriteAllBytes(PDFpath, abc);
            MemoryStream ms = new MemoryStream(abc);
            return new FileStreamResult(ms, "application/pdf");
        }

        public IActionResult EducationIndex()
        {
            var Edu = context.Education.ToList();
            return View(Edu);
        }

        public IActionResult EducationView(int ID)
        {
            var source = context.Education.SingleOrDefault(x => x.ID == ID);
            return View(source);
        }
    }
}
