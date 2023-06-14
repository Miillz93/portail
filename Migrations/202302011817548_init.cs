namespace portail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
