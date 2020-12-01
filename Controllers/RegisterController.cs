using portail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portail.Controllers
{
    public class RegisterController : Controller
    {

        private PortailContext db = new PortailContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == user.Email);

                if (check == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View("Index");
                }


            }

            return View("Index" , user);
        }




    }
}