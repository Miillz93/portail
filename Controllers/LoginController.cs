using portail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portail.Controllers
{
    public class LoginController : Controller
    {
        private PortailContext db = new PortailContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var data = new List<User>();

            if (ModelState.IsValid)
            {

                data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();


                if (data.Count() > 0)
                {

                    //add session
                    Session["fullname"] = data.FirstOrDefault().Firstname + " " + data.FirstOrDefault().Lastname;
                    Session["email"] = data.FirstOrDefault().Email;
                    Session["id"] = data.FirstOrDefault().User_id;

                    if (data.FirstOrDefault().Status == false)
                    {
                        return RedirectToAction("Index", "Admin");

                    }
                    else
                    {
                        return RedirectToAction("Index", "User");

                    }
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        // GET: Login/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Login/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Login/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Login/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Login/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
