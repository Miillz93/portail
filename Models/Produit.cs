using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace portail.Models
{
    public class Produit
    {
        [Key]
        public int Produit_id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public double prix { get; set; }
        public  string imgUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadFile { get; set; }


        public Produit()
        {

        }

        public Produit(int produit_id, string reference, string description, double prix)
        {
            Produit_id = produit_id;
            Reference = reference;
            Description = description;
            //this.imgUrl = imgUrl;
            this.prix = prix;
        }
    }
}