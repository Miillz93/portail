using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace portail.Models
{
    //public class PortailContext: DbContext
    public class PortailContext : IdentityDbContext<User>

    {

        public PortailContext(): base("name=portail")
        {

        }

        public static PortailContext Create()
        {
            return new PortailContext();
        }

        public DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<IdentityUserClaim> Claims { get; set; }
        public DbSet<IdentityUserLogin> Logins { get; set; }


        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Produit> Produits { get; set; }
    }
}