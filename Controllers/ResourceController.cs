using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectForHealing.Models;
using ProjectForHealing.ViewModels;

namespace ProjectForHealing.Controllers
{
    public class ResourceController : Controller
    {
        private CRMSContext context;
        private readonly IWebHostEnvironment hostingEnvironment;
        //asking to get instance of CRMS context
        private String emailAdd;
        public ResourceController(CRMSContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Submitted()
        {

            sendEmail();
            return View();
        }

        public IActionResult Add()
        {
            AddResourceViewModel addResourceViewModel = new AddResourceViewModel();
            return View(addResourceViewModel);
        }
   

        [HttpPost]
        [Route("/Resource/Add")]
        public IActionResult Add(AddResourceViewModel addResourceViewModel)
        {

        
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                //if the actual file is not null

                


                if(addResourceViewModel.UploadedFile != null)
                {
                  string uploadsFolder =  Path.Combine(hostingEnvironment.WebRootPath, "ResourceFiles");
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + addResourceViewModel.UploadedFile.FileName;
                   string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    addResourceViewModel.UploadedFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                string[] holding = new string[3];
                int i = 0;
               while(i < addResourceViewModel.ResourceTypes.Length)
                {
                    holding[i] = addResourceViewModel.ResourceTypes[i];
                    i++;
                }
                Resource newResource = new Resource
                {
                    //  ResourceID = addResourceViewModel.ResourceID,
                    OrgName = addResourceViewModel.OrgName,
                    OrgNumber = addResourceViewModel.OrgNumber,
                    OrgEmail = addResourceViewModel.OrgEmail,
                    OrgAddress = addResourceViewModel.OrgAddress,
                    OrgZip = addResourceViewModel.OrgZip,
                    OrgSte = addResourceViewModel.OrgSte,
                    OrgDescription = addResourceViewModel.OrgDescription,
                    WebsiteUrl = addResourceViewModel.WebsiteUrl,
                    PhotoPath = uniqueFileName,
                    IsApproved = addResourceViewModel.IsApproved,
                    RType1 = holding[0],

                    RType2 = holding[1],

                    RType3 = holding[2],
                    lat = addResourceViewModel.lat,
                    lng = addResourceViewModel.lng,
                    Tag1 = addResourceViewModel.Tag1,
                    Tag2 = addResourceViewModel.Tag2,
                    Tag3 = addResourceViewModel.Tag3,
                    Tag4 = addResourceViewModel.Tag4,
                    Tag5 = addResourceViewModel.Tag5


                };
                context.Resource.Add(newResource);
                context.SaveChanges();
                emailAdd = newResource.OrgEmail;
                return Redirect("/Resource/Submitted");
            }
            else
            {
                return View(addResourceViewModel);
            }
            
        }


        public void sendEmail()
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("chingchong@gmail.com");
            mail.To.Add("abc03199@gmail.com");
            mail.Subject = "Submission Test Email";
            mail.Body = "This is a test email from Neighborly.org ";


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("abc031998@gmail.com", "Xrtfvptbpzmq1308dizz1");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}