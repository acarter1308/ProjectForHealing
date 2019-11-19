using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectForHealing.Models;
using ProjectForHealing.ViewModels;

namespace ProjectForHealing.Controllers
{
    public class AdminController : Controller
    {

        private CRMSContext context;

        public AdminController(CRMSContext dbContext)
        {
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
            return View();
        }
        public IActionResult AddEditor()
        {
            return View();
        }
        

        [HttpPost]
        [Route("/Admin/AddEditor")]
        public IActionResult Add(AddEditorViewModel addEditorViewModel)
        {

            if (ModelState.IsValid)
            {
                Editor newEditor = new Editor
                {
                    //  ResourceID = addEditorViewModel.ResourceID,
                    UserName = addEditorViewModel.UserName,
                    Fname = addEditorViewModel.Fname,
                    Lname = addEditorViewModel.Lname,
                    Email = addEditorViewModel.Email,
                    Pnumber = addEditorViewModel.Pnumber,
                    EditorPassWord = addEditorViewModel.EditorPassWord,
                    ProfilePicUrl = addEditorViewModel.ProfilePicUrl,
                };
                context.Editor.Add(newEditor);
                context.SaveChanges();
                return Redirect("/Admin/Created");
            }
            else
            {
                return View(addEditorViewModel);
            }

        }

        public IActionResult ResourceManage()
        {

            List<Resource> resources = context.Resource.ToList();


            return View(resources);
        }

        public IActionResult Remove()
        {
            ViewBag.resources = context.Resource.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] resourceIDs)
        {
            foreach (int resourceID in resourceIDs)
            {
                // ResourceData.Remove(resourceID);
                // Resources.RemoveAll(x => x.ResourceID == resourceID);
                Resource theResource = context.Resource.Single(x => x.ResourceID == resourceID);
                context.Resource.Remove(theResource);

            }
            context.SaveChanges();
            return Redirect("/Admin/ResourceManage");
        }


    }
}