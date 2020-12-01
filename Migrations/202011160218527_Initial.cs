namespace portail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Produit_id = c.Int(nullable: false, identity: true),
                        Reference = c.String(),
                        Description = c.String(),
                        prix = c.Double(nullable: false),
                        imgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Produit_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
