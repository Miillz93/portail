using portail.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace portail.Controllers
{
    public class AdminController : Controller
    {
        private PortailContext db = new PortailContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateProduit()
        {
            return View("Produit/CreateProduit");
        }

        [HttpPost]
        public ActionResult CreateProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                string strDatetime = System.DateTime.Now.ToString("ddMMyyyy");
                try
                {
                    string finalPath = "\\UploadedFile\\" + strDatetime + produit.UploadFile.FileName;
                    produit.UploadFile.SaveAs(Server.MapPath("~") + finalPath);
                    produit.imgUrl = finalPath;

                    db.Produits.Add(produit);
                    db.SaveChanges();

                    return RedirectToAction("GetAllProducts");
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message.ToString();
                }

                    
            }

            return View("Index", produit);
        }


        public ActionResult GetAllProducts()
        {
            return View("Produit/GetAllProduct", db.Produits.ToList());
        }

        public ActionResult EditProduit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit produit = db.Produits.Find(id);

            if (produit == null)
            {
                return HttpNotFound();
            }
            return View("Produit/EditProduct", produit);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditProduit(Produit produit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(produit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("GetAllProducts");
        //    }
        //    return View("Produit/EditProduct", produit);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduit([Bind(Include = "Produit_id, Reference, Description, prix, imgUrl")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetAllProducts");

            }

            return View("Produit/EditProduct", produit);




        }




        public ActionResult DeleteProduit(int ? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit produit = db.Produits.Find(id);

            if (produit == null)
            {
                return HttpNotFound();
            }
            return View("Produit/DeleteProduct", produit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduitConfirmed([Bind(Include = "Produit_id, Reference, Description, prix, imgUrl")] Produit produit)
        {
            db.Entry(produit).State = EntityState.Deleted;
            db.Produits.Remove(produit);
                db.SaveChanges();
                return RedirectToAction("GetAllProducts");

        }


        public ActionResult CreateCategory(Category category)
        {
           

            return View("Index", category);
        }

        public ActionResult GetAllCategories()
        {
            return View("Category/GetAllCategories");
        }
    }
}