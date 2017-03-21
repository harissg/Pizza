namespace HotStuffPizzaAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Reciepe_ReciepeID", "dbo.Reciepes");
            DropIndex("dbo.Ingredients", new[] { "Reciepe_ReciepeID" });
            CreateTable(
                "dbo.ProductReciepes",
                c => new
                    {
                        ProductReciepeID = c.Int(nullable: false, identity: true),
                        ReciepeID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductReciepeID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Reciepes", t => t.ReciepeID, cascadeDelete: true)
                .Index(t => t.ReciepeID)
                .Index(t => t.ProductID)
                .Index(t => t.IngredientID);
            
            AddColumn("dbo.Reciepes", "Description", c => c.String());
            DropColumn("dbo.Ingredients", "Reciepe_ReciepeID");
            DropColumn("dbo.Reciepes", "IngredientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reciepes", "IngredientID", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredients", "Reciepe_ReciepeID", c => c.Int());
            DropForeignKey("dbo.ProductReciepes", "ReciepeID", "dbo.Reciepes");
            DropForeignKey("dbo.ProductReciepes", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductReciepes", "IngredientID", "dbo.Ingredients");
            DropIndex("dbo.ProductReciepes", new[] { "IngredientID" });
            DropIndex("dbo.ProductReciepes", new[] { "ProductID" });
            DropIndex("dbo.ProductReciepes", new[] { "ReciepeID" });
            DropColumn("dbo.Reciepes", "Description");
            DropTable("dbo.ProductReciepes");
            CreateIndex("dbo.Ingredients", "Reciepe_ReciepeID");
            AddForeignKey("dbo.Ingredients", "Reciepe_ReciepeID", "dbo.Reciepes", "ReciepeID");
        }
    }
}
