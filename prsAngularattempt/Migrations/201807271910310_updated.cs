namespace prsAngularattempt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequestLines", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseRequestLines", "ProductId");
            AddForeignKey("dbo.PurchaseRequestLines", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLines", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseRequestLines", new[] { "ProductId" });
            DropColumn("dbo.PurchaseRequestLines", "ProductId");
        }
    }
}
