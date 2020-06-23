using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ProjectForHealing.Models;
using ProjectForHealing.ViewModels;

namespace ProjectForHealing.Controllers
{
    public class AdminController : Controller
    {

        private CRMSContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        public AdminController(CRMSContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            context = dbContext;
        }
        
        //checks if logged in before being able to interact with any function in this controller
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext.Session.TryGetValue("username", out var bytes);
            if (bytes == null)
            {
                context.Result = new RedirectResult("/");
                return;
            }
            var username = Encoding.UTF8.GetString(bytes);

            if (string.IsNullOrWhiteSpace(username))
            {
                context.Result = new RedirectResult("/");
                return;
            }

            
            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
           ViewBag.name = HttpContext.Session.GetString("fname") + " " + HttpContext.Session.GetString("lname");
           ViewBag.email = HttpContext.Session.GetString("email");
            ViewBag.number = HttpContext.Session.GetString("pnumber");
            ViewBag.role = HttpContext.Session.GetString("role");
            if (HttpContext.Session.GetString("pic") != "null")
            {
                ViewBag.pic = HttpContext.Session.GetString("pic");
            }
           
            return View();
        }
        public IActionResult AddAdmin()
        {
            return View();
        }
        

        [HttpPost]
        [Route("/Admin/AddAdmin")]
        public IActionResult AddAdmin(AdminViewModel model)
        {
        
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                //if the actual file is not null
                if (model.UploadedFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "ProfilePictures");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadedFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.UploadedFile.CopyTo(new FileStream(filePath, FileMode.Create));
              
                }
                Admin newAdmin = new Admin
                {
                    //  ResourceID = addEditorViewModel.ResourceID,
                    UserName = model.UserName,
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Email = model.Email,
                    Pnumber = model.Pnumber,
                    AdminPassWord = model.AdminPassWord,
                    ProfilePic = model.ProfilePic,
                    SuperUser = model.SuperUser,
                    PhotoPath = uniqueFileName
                };
                context.Admin.Add(newAdmin);
                context.SaveChanges();
                return Redirect("/Admin/Created");
            }
            else
            {
                return View(model);
            }

        }
        public IActionResult Created()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // todo: add validation for editing a resource
            var source = context.Resource.SingleOrDefault(x => x.ResourceID == id);
            return View(source);
        }
        [HttpPost]
        public IActionResult Edit(Resource source)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["ResourceTypes"].ToArray().Length == 1)
                {
                    source.RType1 = Request.Form["ResourceTypes"][0];

                }

                else if (Request.Form["ResourceTypes"].ToArray().Length == 2)
                {
                    source.RType1 = Request.Form["ResourceTypes"][0];
                    source.RType2 = Request.Form["ResourceTypes"][1];
                }
                else if (Request.Form["ResourceTypes"].ToArray().Length == 3)
                {
                    source.RType1 = Request.Form["ResourceTypes"][0];
                    source.RType2 = Request.Form["ResourceTypes"][1];
                    source.RType3 = Request.Form["ResourceTypes"][2];
                }
                else
                {

                }
                    

                context.Entry(source).State = EntityState.Modified;
                context.SaveChanges();
                ViewBag.Title = "Changes Saved";
                return View(source);
            }
            ViewBag.Title = "Changes not saved";
            return View(source);
        }
        public IActionResult ResourceManage()
        {

         
            var model = new ManageViewModel();
            model.resources = context.Resource.ToList();
            model.unassocResources = context.UnassocResource.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Unapproved() {

            List<Resource> resources = context.Resource.Where(x => x.IsApproved == false).ToList();
            return View(resources);
            
            
        }


       
        public IActionResult AdminList()
        {
            var admins = context.Admin.Where(x => x.SuperUser == false);
        
            return View(admins);
        }



        [HttpGet]
        public IActionResult RemoveAdmin(string UserName)
        {

            Admin admin = context.Admin.SingleOrDefault(x => x.UserName == UserName);
            context.Admin.Remove(admin);
            string files = Path.Combine(hostingEnvironment.WebRootPath, "ProfilePictures/");

            FileInfo file = new FileInfo(files + admin.PhotoPath);

            if (file.Exists)
            {
                file.Delete();
            }
            context.SaveChanges();
            return Redirect("/Admin");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {

            Resource theResource = context.Resource.SingleOrDefault(x => x.ResourceID == id);
            context.Resource.Remove(theResource);
       string files = Path.Combine(hostingEnvironment.WebRootPath, "ResourceFiles/");

            FileInfo file = new FileInfo(files + theResource.PhotoPath);

            if (file.Exists)
            {
                file.Delete();
            }
            context.SaveChanges();
            return Redirect("/Admin/ResourceManage");
        }


        [HttpGet]
        public IActionResult Approve(int id )
        {
          
            Resource theResource = context.Resource.SingleOrDefault(x => x.ResourceID == id);
            theResource.IsApproved = true;
            sendEmail();
            
            context.SaveChanges();
            return Redirect("/Admin/ResourceManage");
        }
/*
           [HttpGet]
        public IActionResult ViewSource(int id)
        {
            var source = context.Resource.SingleOrDefault(x => x.ResourceID == id);
            return View(source);
        }
        */
        public IActionResult AddUnassocResource()
        {
            UnassocViewModel rec = new UnassocViewModel();
            return View(rec);
        }

        [HttpPost]
        [Route("/Admin/AddUnassocResource")]
        public IActionResult AddUnassocResource(UnassocViewModel model)
        {


            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
               
                //if the actual file is not null
                if (model.UploadedFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "ResourceFiles");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadedFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.UploadedFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                UnassocResource newRec = new UnassocResource
                {
                    //  ResourceID = addEditorViewModel.ResourceID,
                    Name = model.Name,
                   Description = model.Description,
                    FilePath = uniqueFileName
                };
                context.UnassocResource.Add(newRec);
                context.SaveChanges();
                return Redirect("/Resource/Submitted");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult UnassocResourceList()
        {
            var rec = context.UnassocResource.ToList();
            return View(rec);
        }

        public IActionResult DelUnassocResource(int id )
        {
            var education = context.UnassocResource.SingleOrDefault(x => x.ID == id);
            context.UnassocResource.Remove(education);
            if (education.FilePath != null)
            {
                string files = Path.Combine(hostingEnvironment.WebRootPath, "ResourceFiles/");
                FileInfo file = new FileInfo(files + education.FilePath);
                if (file.Exists)
                {
                    file.Delete();
                }

            }
        



            context.SaveChanges();
            return Redirect("/Home/UnassocResources");
            
        }

        public void sendEmail()
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("abc031998@gmail.com");
            mail.To.Add("mrmain00@protonmail.com");
            mail.Subject = "Approval Test Email";
            mail.Body = "This is a test email from Neighborly.org to verify that your email has been submitted ";


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("abc031998@gmail.com", "Xrtfvptbpzmq1308dizz1");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }


    }
}