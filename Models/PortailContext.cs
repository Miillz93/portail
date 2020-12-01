using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace portail.Models
{
    public class PortailContext: DbContext
    {

        public PortailContext(): base("name=machaine")
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Produit> Produits { get; set; }
    }
}