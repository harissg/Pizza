namespace HotStuffPizzaAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Reciepe_ReciepeID = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientID)
                .ForeignKey("dbo.Reciepes", t => t.Reciepe_ReciepeID)
                .Index(t => t.Reciepe_ReciepeID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        ProductTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        Descripton = c.String(),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Reciepes",
                c => new
                    {
                        ReciepeID = c.Int(nullable: false, identity: true),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReciepeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Reciepe_ReciepeID", "dbo.Reciepes");
            DropIndex("dbo.Ingredients", new[] { "Reciepe_ReciepeID" });
            DropTable("dbo.Reciepes");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Ingredients");
        }
    }
}
