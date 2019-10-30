using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Created()
        {
            return View();
        }
    }
}