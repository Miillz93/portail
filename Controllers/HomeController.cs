using portail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace portail.Controllers
{
    public class HomeController : Controller
    {

        private PortailContext db = new PortailContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalogue()
        {
            ViewBag.Message = "Catalogue page.";

            return View("Catalogue", db.Produits.ToList());
        }

        public ActionResult CatalogueDetails(int? id)
        {
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit produit = db.Produits.Find(id);

            if(produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
        }
    }
}