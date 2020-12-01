using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace portail.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Libelle { get; set; }
    }
}