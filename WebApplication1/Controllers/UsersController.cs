using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ViewResult Index()
        {
            var products = context.Users.ToList();
            return View("Index", products);
        }
        //Create
        public ViewResult Create()
        {
            return View("Create", new User());
        }

        public IActionResult Store(User request)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", request);
           
        }

        //Details
        public IActionResult Details(int id)
        { 
           var user = context.Users.Find(id);
            return View("Details", user);
        }

        //Edit button
        public IActionResult Edit(int id)
        {
            var user = context.Users.Find(id);
            return View("Edit", user);
        }

        //Uodate
        public IActionResult Update(User request, int id)
        {
            request.Id = id;
            context.Users.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}